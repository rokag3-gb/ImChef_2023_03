namespace WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class ImChef2023Controller : ControllerBase
    {
        private readonly DapperContext _context;
        private readonly ILogger<ImChef2023Controller> _logger;

        public ImChef2023Controller(
            DapperContext context
            , ILogger<ImChef2023Controller> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        [Route("/ImChef2023/player/")]
        [HttpGet]
        public async Task<IEnumerable<ImChefModel_player>> Get_player()
        {
            string conn_str = Secret.conn_str_CM_DEV_DB;

            try
            {
                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    var players = await conn.QueryAsync<ImChefModel_player>("select player_id, player_name, food_name, note, saved_at from DB1.food.player;");

                    if (conn.State == ConnectionState.Open) conn.Close();

                    return players;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("/ImChef2023/vote/")]
        [HttpPost]
        public async Task<ActionResult> Insert_vote(ImChefModel_vote vote)
        {
            string conn_str = Secret.conn_str_CM_DEV_DB;
            
            try
            {
                var param = new DynamicParameters();
                param.Add("player_id", vote.player_id);
                
                int effected_row = 0;

                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    effected_row = conn.Execute("insert into DB1.food.vote (player_id) values (@player_id);", param);

                    if (conn.State == ConnectionState.Open) conn.Close();
                }

                return StatusCode(200, $"effected_row = {effected_row}");
                //return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("/ImChef2023/vote/")]
        [HttpGet]
        public async Task<IEnumerable<ImChefModel_vote>> Get_vote()
        {
            string conn_str = Secret.conn_str_CM_DEV_DB;

            try
            {
                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    var players = await conn.QueryAsync<ImChefModel_vote>(
                        "select"
                        + " v.vote_id"
                        + ", v.voted_at"
                        + ", v.player_id"
                        + " from DB1.food.vote v;");

                    if (conn.State == ConnectionState.Open) conn.Close();

                    return players;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("/ImChef2023/vote/aggregate")]
        [HttpGet]
        public async Task<IEnumerable<ImChefModel_vote_aggregate>> Get_vote_aggregate()
        {
            string conn_str = Secret.conn_str_CM_DEV_DB;

            try
            {
                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    var players = await conn.QueryAsync<ImChefModel_vote_aggregate>(
                        "select"
                        + " vote_count = count(v.vote_id)"
                        + ", ranking = dense_rank() over(order by count(v.vote_id) desc)"
                        + ", v.player_id"
                        + ", player_name = max(p.player_name)"
                        + ", food_name = max(p.food_name)"
                        + " from DB1.food.vote v"
                        + " inner join DB1.food.player p on v.player_id = p.player_id"
                        + " group by v.player_id"
                        + " order by vote_count desc;"
                        );

                    if (conn.State == ConnectionState.Open) conn.Close();

                    return players;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("/ImChef2023/vote/")]
        [HttpDelete]
        public async Task<ActionResult> Clear_vote()
        {
            string conn_str = Secret.conn_str_CM_DEV_DB;

            try
            {
                //var param = new DynamicParameters();
                //param.Add("player_id", vote.player_id);

                int effected_row = 0;

                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    effected_row = conn.Execute("delete from DB1.food.vote;");

                    if (conn.State == ConnectionState.Open) conn.Close();
                }

                return StatusCode(200, $"effected_row = {effected_row}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("/ImChef2023/vote/period")]
        [HttpGet]
        public async Task<IEnumerable<ImChefModel_vote_period>> Get_vote_period()
        {
            string conn_str = Secret.conn_str_CM_DEV_DB;

            try
            {
                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    var players = await conn.QueryAsync<ImChefModel_vote_period>(
                        "select"
                        + " v.id"
                        + ", v.vote_start"
                        + ", v.vote_end"
                        + " from DB1.food.vote_period v;");

                    if (conn.State == ConnectionState.Open) conn.Close();

                    return players;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}