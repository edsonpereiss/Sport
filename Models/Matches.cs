// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Sport.Models.Matches;
//
//    MatchesRounds matches = MatchesRounds.FromJson(result.strJson);

namespace Sport.Models.Matches
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MatchesRounds
    {
        [JsonProperty("data")]
        public DataRounds Data { get; set; }
    }

    public partial class DataRounds
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("league_id")]
        //public long LeagueId { get; set; }

        //[JsonProperty("is_current_season")]
        //public bool IsCurrentSeason { get; set; }

        [JsonProperty("current_round_id")]
        public long CurrentRoundId { get; set; }

        //[JsonProperty("current_stage_id")]
        //public long CurrentStageId { get; set; }

        [JsonProperty("rounds")]
        public Rounds Rounds { get; set; }

        [JsonProperty("fixtures")]
        public Fixtures Fixtures { get; set; }
    }

    public partial class Fixtures
    {
        [JsonProperty("data")]
        public FixturesDatum[] Data { get; set; }
    }

    public partial class FixturesDatum
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        //[JsonProperty("league_id")]
        //public long LeagueId { get; set; }

        //[JsonProperty("season_id")]
        //public long SeasonId { get; set; }

        //[JsonProperty("stage_id")]
        //public long StageId { get; set; }

        [JsonProperty("round_id")]
        public long RoundId { get; set; }

        [JsonProperty("group_id")]
        public object GroupId { get; set; }

        //[JsonProperty("aggregate_id")]
        //public object AggregateId { get; set; }

        [JsonProperty("venue_id")]
        public long? VenueId { get; set; }

        //[JsonProperty("referee_id")]
        //public long? RefereeId { get; set; }

        [JsonProperty("localteam_id")]
        public long LocalteamId { get; set; }

        [JsonProperty("visitorteam_id")]
        public long VisitorteamId { get; set; }

        [JsonProperty("winner_team_id")]
        public long? WinnerTeamId { get; set; }

        [JsonProperty("weather_report")]
        public WeatherReport WeatherReport { get; set; }

        [JsonProperty("commentaries")]
        public bool Commentaries { get; set; }

        //[JsonProperty("attendance")]
        //public object Attendance { get; set; }

        //[JsonProperty("pitch")]
        //public object Pitch { get; set; }

        //[JsonProperty("details")]
        //public object Details { get; set; }

        //[JsonProperty("neutral_venue")]
        //public bool NeutralVenue { get; set; }

        [JsonProperty("winning_odds_calculated")]
        public bool WinningOddsCalculated { get; set; }

        [JsonProperty("formations")]
        public Formations Formations { get; set; }

        [JsonProperty("scores")]
        public Scores Scores { get; set; }

        [JsonProperty("time")]
        public Time Time { get; set; }

        [JsonProperty("coaches")]
        public Coaches Coaches { get; set; }

        [JsonProperty("standings")]
        public Standings Standings { get; set; }

        [JsonProperty("assistants")]
        public Assistants Assistants { get; set; }

        [JsonProperty("leg")]
        public string Leg { get; set; }

        [JsonProperty("colors")]
        public Colors Colors { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("is_placeholder")]
        public bool IsPlaceholder { get; set; }
    }

    public partial class Assistants
    {
        [JsonProperty("first_assistant_id")]
        public long? FirstAssistantId { get; set; }

        [JsonProperty("second_assistant_id")]
        public long? SecondAssistantId { get; set; }

        [JsonProperty("fourth_official_id")]
        public long? FourthOfficialId { get; set; }
    }

    public partial class Coaches
    {
        [JsonProperty("localteam_coach_id")]
        public long? LocalteamCoachId { get; set; }

        [JsonProperty("visitorteam_coach_id")]
        public long? VisitorteamCoachId { get; set; }
    }

    public partial class Colors
    {
        [JsonProperty("localteam")]
        public Team Localteam { get; set; }

        [JsonProperty("visitorteam")]
        public Team Visitorteam { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("kit_colors")]
        public string KitColors { get; set; }
    }

    public partial class Formations
    {
        [JsonProperty("localteam_formation")]
        public string LocalteamFormation { get; set; }

        [JsonProperty("visitorteam_formation")]
        public string VisitorteamFormation { get; set; }
    }

    public partial class Scores
    {
        [JsonProperty("localteam_score")]
        public long LocalteamScore { get; set; }

        [JsonProperty("visitorteam_score")]
        public long VisitorteamScore { get; set; }

        [JsonProperty("localteam_pen_score")]
        public object LocalteamPenScore { get; set; }

        [JsonProperty("visitorteam_pen_score")]
        public object VisitorteamPenScore { get; set; }

        [JsonProperty("ht_score")]
        public string HtScore { get; set; }

        [JsonProperty("ft_score")]
        public string FtScore { get; set; }

        [JsonProperty("et_score")]
        public object EtScore { get; set; }

        [JsonProperty("ps_score")]
        public object PsScore { get; set; }
    }

    public partial class Standings
    {
        [JsonProperty("localteam_position")]
        public long? LocalteamPosition { get; set; }

        [JsonProperty("visitorteam_position")]
        public long? VisitorteamPosition { get; set; }
    }

    public partial class Time
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("starting_at")]
        public StartingAt StartingAt { get; set; }

        [JsonProperty("minute")]
        public long? Minute { get; set; }

        [JsonProperty("second")]
        public object Second { get; set; }

        [JsonProperty("added_time")]
        public object AddedTime { get; set; }

        [JsonProperty("extra_minute")]
        public object ExtraMinute { get; set; }

        [JsonProperty("injury_time")]
        public object InjuryTime { get; set; }
    }

    public partial class StartingAt
    {
        [JsonProperty("date_time")]
        public DateTimeOffset DateTime { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }

    public partial class WeatherReport
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("icon")]
        public Uri Icon { get; set; }

        [JsonProperty("temperature")]
        public Temperature Temperature { get; set; }

        [JsonProperty("temperature_celcius")]
        public Temperature TemperatureCelcius { get; set; }

        [JsonProperty("clouds")]
        public string Clouds { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public partial class Coordinates
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public partial class Temperature
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public partial class Wind
    {
        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("degree")]
        public long Degree { get; set; }
    }

    public partial class Rounds
    {
        [JsonProperty("data")]
        public RoundsDatum[] Data { get; set; }
    }

    public partial class RoundsDatum
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public long Name { get; set; }

        //[JsonProperty("league_id")]
        //public long LeagueId { get; set; }

        //[JsonProperty("season_id")]
        //public long SeasonId { get; set; }

        //[JsonProperty("stage_id")]
        //public long StageId { get; set; }

        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }

        [JsonProperty("end")]
        public DateTimeOffset End { get; set; }
    }

    public partial class MatchesRounds
    {
        public static MatchesRounds FromJson(string json) => JsonConvert.DeserializeObject<MatchesRounds>(json, Matches.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MatchesRounds self) => JsonConvert.SerializeObject(self, Matches.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }


    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
