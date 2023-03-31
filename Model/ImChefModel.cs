namespace WebAPI
{
    public class ImChefModel_player
    {
        public Int64 player_id { get; set; }
        public string player_name { get; set; }
        public string food_name { get; set; }
        public string note { get; set; }
        public DateTime saved_at { get; set; }
    }

    public class ImChefModel_vote
    {
        public Int64 vote_id { get; set; }
        public DateTime voted_at { get; set; }
        public Int64 player_id { get; set; }
    }

    public class ImChefModel_vote_period
    {
        public Int64 id { get; set; }
        public DateTime vote_start { get; set; }
        public DateTime vote_end { get; set; }
    }

    public class ImChefModel_vote_aggregate
    {
        public Int64 vote_count { get; set; }
        public Int64 ranking { get; set; }
        public Int64 player_id { get; set; }
        public string player_name { get; set; }
        public string food_name { get; set; }
    }
}