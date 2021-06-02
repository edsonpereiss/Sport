using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
using RestSharp;
using Sport.Extensions;
using Sport.Repositories;
using Sport.Entities;

namespace Sport.Controllers
{
    public class ParamApi
    {
        public NameValueCollection Qry { get; set; }
        public NameValueCollection Rst { get; set; }
        public ParamApi()
        {
            Qry = new NameValueCollection();
            Rst = new NameValueCollection();
        }
    }
     public enum ApiRef
     {
        countries,
        leagues,
        leagueById,
        standings,
        teamById,
        livescores,
        livescoresNow,
        fixturesByIdLive,
        seasonTeams,
        seasonResults,
        seasonSquad,
        seasonTopPlayers,
        fixturesById,
        fixturesBetweenDates,
        fixturesForDate,
        particularFixtures,
        commentary,
        player,
        h2h
    }

    public class DataCallback  
    {
        public static IRestResponse CallBack(ApiRef apiref, ParamApi ParamApi, IFootballRepository repository)
        {
            string querys = ToQueryString(ParamApi.Qry);
            string path = ToParamRstString(ParamApi.Rst, Config.GetConfig(apiref.ToString() + ":path", false));
            string uri =  Config.GetConfig("URL_BASE", false) + path + querys;
            int executionTimeout = Convert.ToInt32(Config.GetConfig(apiref.ToString() + ":executionTimeout", false));
            return CallFootball(apiref, uri, executionTimeout, repository);
        }

        private static IRestResponse CallFootball(ApiRef apiref, string uri, int executionTimeout, IFootballRepository repository)
        {
            bool call = false;
            Football football = repository.GetFootballByName(uri).Result;
            bool footballExist = football is not null;
            IRestResponse response = new RestResponse();;

            if (footballExist)
            {
                DateTime lastUpdate = football.LastUpdate;
                DateTime currentUpdate = lastUpdate.AddSeconds(executionTimeout);
                call = currentUpdate < DateTime.UtcNow;
            }
            else
            {
                call = true;
            }

            if (call)
            {
                var client = new RestClient(uri);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                response = client.Execute(request);
                if (!response.IsSuccessful)
                {
                    if (footballExist)
                    {
                        response.Content = football.jsonFile;
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    return response;
                }                
            }

            if ((call) && (footballExist))
            {
                football.jsonFile = response.Content;
                football.LastUpdate = DateTime.UtcNow;
                repository.UpadateFootball(football);
            }
            else if ((call) && (!footballExist))
            {
                football = new Football();
                football.Name = uri;
                football.jsonFile = response.Content;
                football.LastUpdate = System.DateTime.UtcNow; 
                repository.CreateFootball(football);
            }
            
            response.Content = football.jsonFile;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;

        }
        private static string ToQueryString(NameValueCollection qry)
        {
            var array = (
                from key in qry.AllKeys
                from value in qry.GetValues(key)
                select string.Format(
                "{0}={1}",
                    HttpUtility.UrlEncode(key),
                    HttpUtility.UrlEncode(value))
            ).ToArray();
        return "?" + string.Join("&", array);
        }


       private static string ToParamRstString(NameValueCollection rst, string path)
        {
            string tmp_path = path;
            foreach (var item in rst.AllKeys)
            {
             string[] value = rst.GetValues(item);
               tmp_path = tmp_path.Replace("{" + item + "}", value[0]);     
            }
            return tmp_path;
        }

    }
    

}