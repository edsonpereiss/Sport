using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using Sport.Repositories;
using Newtonsoft.Json;
using Sport.Models;

namespace Sport.Controllers
{
    public class ResultJson
    {
        public object objJson {get; set;}
        public string strJson {get; set;}        
    }

    [ApiController]
    [Route("football/api/v1.0")]
    public class FootballController : ControllerBase
    {

        private readonly ILogger<FootballController> _logger;
        private readonly IFootballRepository _repository;

        protected readonly string error_api_token = "{ \"error\": { \"message\": \"Unauthenticated\", \"code\": 403 }}";

        public FootballController(ILogger<FootballController> logger, IConfiguration iconfiguration, IFootballRepository repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("countries")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object countries(string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            return CallApi(ApiRef.countries, paramApi).objJson;    
        }

        [HttpGet]
        [Route("leagues")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object leagues(string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            return CallApi(ApiRef.leagues, paramApi).objJson;     
        }

        [HttpGet]
        [Route("leagues/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object leagueById(long id, string api_token  = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            paramApi.Rst.Add("id", id.ToString());

            return CallApi(ApiRef.leagueById, paramApi).objJson;       
        }

        [HttpGet]
        [Route("fixtures/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object fixturesForDate(long id, string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("id", id.ToString());

            return CallApi(ApiRef.fixturesById, paramApi).objJson;       
        }

        [HttpGet]
        [Route("fixtures/date/{date}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object fixturesForDate(string date, string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("date", date);

            return CallApi(ApiRef.fixturesForDate, paramApi).objJson;       
        }

        [HttpGet]
        [Route("fixtures/between/{from}/{to}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object fixturesBetweenDates(string from, string to, string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("from", from);
            paramApi.Rst.Add("to", to);

            return CallApi(ApiRef.fixturesBetweenDates, paramApi).objJson;      
        }

        [HttpGet]
        [Route("fixtures/multi/{ids}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object particularFixtures(string ids, string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("ids", ids);

            return CallApi(ApiRef.particularFixtures, paramApi).objJson;       
        }

        [HttpGet]
        [Route("commentaries/fixture/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object commentary(long id, string api_token  = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            paramApi.Rst.Add("id", id.ToString());

            return CallApi(ApiRef.commentary, paramApi).objJson;       
        }

        [HttpGet]
        [Route("players/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object player(long id, string api_token  = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            paramApi.Rst.Add("id", id.ToString());

            return CallApi(ApiRef.player, paramApi).objJson;       
        }

        [HttpGet]
        [Route("head2head/{team1id}/{team2id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object h2h(long team1id, long team2id, string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("team1id", team1id.ToString());
            paramApi.Rst.Add("team2id", team2id.ToString());

            return CallApi(ApiRef.h2h, paramApi).objJson;       
        }

        [HttpGet]
        [Route("teams/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object teamById(long id, string api_token  = null, string include = null, string compact = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("id", id.ToString());

            //return CallApi(ApiRef.teamById, paramApi).objJson;
            ResultJson result = CallApi(ApiRef.teamById, paramApi);
            if ((result.strJson != null) && (!string.IsNullOrEmpty(compact)))
            {
                if (compact == "1")
                {
                    Models.Teams.Team team = Models.Teams.Team.FromJson(result.strJson);
                    return team;
                }
                else
                {
                    return result.objJson;      
                }
            } 
            return result.objJson;      

        }

        [HttpGet]
        [Route("livescores")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object livescores(string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            return CallApi(ApiRef.livescores, paramApi).objJson;       
        }

        [HttpGet]
        [Route("livescores/now")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object livescoresNow(string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            return CallApi(ApiRef.livescoresNow, paramApi).objJson;      
        }

        [HttpGet]
        [Route("teams/season/{seasonId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object seasonTeams(long seasonId, string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("seasonId", seasonId.ToString());

            return CallApi(ApiRef.seasonTeams, paramApi).objJson;      
        }

        [HttpGet]
        [Route("seasons/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object seasonResults(long id, string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("id", id.ToString());

            return CallApi(ApiRef.seasonResults, paramApi).objJson;      
        }

        [HttpGet]
        [Route("rounds/matches/seasons/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object seasonMatchesByRounds(long id, string api_token  = null, string include = null, string compact = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("id", id.ToString());

            ResultJson result = CallApi(ApiRef.seasonMatchesByRounds, paramApi);
            if ((result.strJson != null) && (!string.IsNullOrEmpty(compact)))
            {
                if (compact == "1")
                {
                    Models.Matches.MatchesRounds matches = Models.Matches.MatchesRounds.FromJson(result.strJson);
                    return matches;
                }
                else
                {
                    return result.objJson;      
                }
            } 
            return result.objJson;       
        }


        [HttpGet]
        [Route("squad/season/{seasonId}/team/{teamId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object seasonSquad(long seasonId, long teamId, string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("seasonId", seasonId.ToString());
            paramApi.Rst.Add("teamId", teamId.ToString());

            return CallApi(ApiRef.seasonSquad, paramApi).objJson;       
        }

        [HttpGet]
        [Route("topscorers/season/{seasonId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public object seasonTopPlayers(long seasonId,  string api_token  = null, string include = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("seasonId", seasonId.ToString());

            return CallApi(ApiRef.seasonTopPlayers, paramApi).objJson;       
        }

        [HttpGet]
        [Route("standings/season/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public  object standings(long id,  string api_token  = null, string include = null, string compact = null)
        {
            ParamApi paramApi = new ParamApi();
            paramApi.Qry.Add("api_token", api_token);

            if (!string.IsNullOrEmpty(include))
                paramApi.Qry.Add("include", include);

            paramApi.Rst.Add("id", id.ToString());
            ResultJson result = CallApi(ApiRef.standings, paramApi);
            if ((result.strJson != null) && (!string.IsNullOrEmpty(compact)))
            {
                if (compact == "1")
                {
                    Models.Standings.StandingsRounds standings = Models.Standings.StandingsRounds.FromJson(result.strJson);
                    return standings;
                }
                else
                {
                    return result.objJson;      
                }
            } 
            return result.objJson;      
        }

        private ResultJson CallApi(ApiRef apiref, ParamApi ParamApi)
        {
            ResultJson result = new ResultJson();
            foreach (var item in ParamApi.Qry.AllKeys)
            {
                if(item.Equals("api_token"))
                    {
                        string[] value = ParamApi.Qry.GetValues(item);
                        if (value == null)
                        {
                            result.objJson = StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden, error_api_token);
                            return result;

                        }
                        if (value[0].Equals(""))
                        {
                            result.objJson = StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden, error_api_token);
                            return result;
                        }
                        break;
                    }
            }
            
            IRestResponse response = DataCallback.CallBack(apiref, ParamApi, _repository);
            
            if (!response.IsSuccessful)
            {
                if (response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
                {
                    result.objJson = StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK,response.Content); 
                    result.strJson = response.Content;
                    return result;

                }
                else
                {
                    result.objJson = StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden,response.Content); 
                    return result;
                }

            }            
            else
            {
               result.objJson = StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK,response.Content); 
               result.strJson = response.Content;
               return result;
            }
        }
    }
}