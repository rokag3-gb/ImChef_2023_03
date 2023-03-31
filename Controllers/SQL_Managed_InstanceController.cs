namespace WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class SQL_Managed_InstanceController : ControllerBase
    {
        private readonly DapperContext _context;
        private readonly ILogger<SQL_Managed_InstanceController> _logger;

        public SQL_Managed_InstanceController(
            DapperContext context
            , ILogger<SQL_Managed_InstanceController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        [Route("/Deal/sqlmi_public_primary/")]
        [HttpGet]
        public async Task<IEnumerable<DealModel>> GetDeal_sqlmi_public_primary(
            string DealDateStart = null
            , string DealDateEnd = null)
        {
            string conn_str = Secret.conn_str_sqlmi_public_primary;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    var deals = await conn.QueryAsync<DealModel>(Query.str_query
                        , new { DealDateStart = DealDateStart, DealDateEnd = DealDateEnd }
                        );

                    if (conn.State == ConnectionState.Open) conn.Close();

                    return deals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("/Deal/sqlmi_public_secondary/")]
        [HttpGet]
        public async Task<IEnumerable<DealModel>> GetDeal_sqlmi_public_secondary(
            string DealDateStart = null
            , string DealDateEnd = null)
        {
            string conn_str = Secret.conn_str_sqlmi_public_secondary;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    var deals = await conn.QueryAsync<DealModel>(Query.str_query
                        , new { DealDateStart = DealDateStart, DealDateEnd = DealDateEnd }
                        );

                    if (conn.State == ConnectionState.Open) conn.Close();

                    return deals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("/Deal/sqlmi_local_primary/")]
        [HttpGet]
        public async Task<IEnumerable<DealModel>> GetDeal_sqlmi_local_primary(
            string DealDateStart = null
            , string DealDateEnd = null)
        {
            string conn_str = Secret.conn_str_sqlmi_local_primary;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    var deals = await conn.QueryAsync<DealModel>(Query.str_query
                        , new { DealDateStart = DealDateStart, DealDateEnd = DealDateEnd }
                        );

                    if (conn.State == ConnectionState.Open) conn.Close();

                    return deals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("/Deal/sqlmi_local_secondary/")]
        [HttpGet]
        public async Task<IEnumerable<DealModel>> GetDeal_sqlmi_local_secondary(
            string DealDateStart = null
            , string DealDateEnd = null)
        {
            string conn_str = Secret.conn_str_sqlmi_local_secondary;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    var deals = await conn.QueryAsync<DealModel>(Query.str_query
                        , new { DealDateStart = DealDateStart, DealDateEnd = DealDateEnd }
                        );

                    if (conn.State == ConnectionState.Open) conn.Close();

                    return deals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("/Deal/sqlmi_fog_readwrite/")]
        [HttpGet]
        public async Task<IEnumerable<DealModel>> GetDeal_sqlmi_fog_readwrite(
            string DealDateStart = null
            , string DealDateEnd = null)
        {
            string conn_str = Secret.conn_str_sqlmi_fog_readwrite_listener;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    var deals = await conn.QueryAsync<DealModel>(Query.str_query
                        , new { DealDateStart = DealDateStart, DealDateEnd = DealDateEnd }
                        );

                    if (conn.State == ConnectionState.Open) conn.Close();

                    return deals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("/Deal/sqlmi_fog_readonly/")]
        [HttpGet]
        public async Task<IEnumerable<DealModel>> GetDeal_sqlmi_fog_readonly(
            string DealDateStart = null
            , string DealDateEnd = null)
        {
            string conn_str = Secret.conn_str_sqlmi_fog_readonly_listener;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    var deals = await conn.QueryAsync<DealModel>(Query.str_query
                        , new { DealDateStart = DealDateStart, DealDateEnd = DealDateEnd }
                        );

                    if (conn.State == ConnectionState.Open) conn.Close();

                    return deals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("/Deal/sqlmi_public_primary/")]
        [HttpPost]
        public async Task<ActionResult> Insert_sqlmi_public_primary(DealModel deal)
        {
            string conn_str = Secret.conn_str_sqlmi_public_primary;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                var param = new DynamicParameters();
                param.Add("DealDate", deal.DealDate);
                param.Add("Item", deal.Item.Trim());
                param.Add("UserId", deal.UserId?.ToString());
                param.Add("Amount", deal.Amount);
                param.Add("Tax", deal.Tax);
                param.Add("Note", deal.Note);

                int effected_row = 0;

                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    effected_row = conn.Execute(Query.str_command, param);

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

        [Route("/Deal/sqlmi_public_secondary/")]
        [HttpPost]
        public async Task<ActionResult> Insert_sqlmi_public_secondary(DealModel deal)
        {
            string conn_str = Secret.conn_str_sqlmi_public_secondary;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                var param = new DynamicParameters();
                param.Add("DealDate", deal.DealDate);
                param.Add("Item", deal.Item.Trim());
                param.Add("UserId", deal.UserId?.ToString());
                param.Add("Amount", deal.Amount);
                param.Add("Tax", deal.Tax);
                param.Add("Note", deal.Note);

                int effected_row = 0;

                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    effected_row = conn.Execute(Query.str_command, param);

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

        [Route("/Deal/sqlmi_local_primary/")]
        [HttpPost]
        public async Task<ActionResult> Insert_sqlmi_local_primary(DealModel deal)
        {
            string conn_str = Secret.conn_str_sqlmi_local_primary;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                var param = new DynamicParameters();
                param.Add("DealDate", deal.DealDate);
                param.Add("Item", deal.Item.Trim());
                param.Add("UserId", deal.UserId?.ToString());
                param.Add("Amount", deal.Amount);
                param.Add("Tax", deal.Tax);
                param.Add("Note", deal.Note);

                int effected_row = 0;

                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    effected_row = conn.Execute(Query.str_command, param);

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

        [Route("/Deal/sqlmi_local_secondary/")]
        [HttpPost]
        public async Task<ActionResult> Insert_sqlmi_local_secondary(DealModel deal)
        {
            string conn_str = Secret.conn_str_sqlmi_local_secondary;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                var param = new DynamicParameters();
                param.Add("DealDate", deal.DealDate);
                param.Add("Item", deal.Item.Trim());
                param.Add("UserId", deal.UserId?.ToString());
                param.Add("Amount", deal.Amount);
                param.Add("Tax", deal.Tax);
                param.Add("Note", deal.Note);

                int effected_row = 0;

                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    effected_row = conn.Execute(Query.str_command, param);

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

        [Route("/Deal/sqlmi_fog_readwrite/")]
        [HttpPost]
        public async Task<ActionResult> Insert_sqlmi_fog_readwrite(DealModel deal)
        {
            //ServicePointManager.DnsRefreshTimeout = 0; // DNS cache 갱신 주기
            //Dns.GetHostEntry("sqlmi-fog-pass-korea.b4ba26535d3d.database.windows.net");
            //Dns.GetHostEntry("sqlmi-fog-pass-korea.secondary.b4ba26535d3d.database.windows.net");
            
            //DnsUtils.FlushCache();
            //Dns.GetHostEntry(Secret.sqlmi_fog_readwrite_listener.Split(',').GetValue(0).ToString());
            //Dns.GetHostEntry(Secret.sqlmi_fog_readonly_listener.Split(',').GetValue(0).ToString());

            string conn_str = Secret.conn_str_sqlmi_fog_readwrite_listener;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                var param = new DynamicParameters();
                param.Add("DealDate", deal.DealDate);
                param.Add("Item", deal.Item.Trim());
                param.Add("UserId", deal.UserId?.ToString());
                param.Add("Amount", deal.Amount);
                param.Add("Tax", deal.Tax);
                param.Add("Note", deal.Note);

                int effected_row = 0;

                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    effected_row = conn.Execute(Query.str_command, param);

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

        [Route("/Deal/sqlmi_fog_readonly/")]
        [HttpPost]
        public async Task<ActionResult> Insert_sqlmi_fog_readonly(DealModel deal)
        {
            //ServicePointManager.DnsRefreshTimeout = 0; // DNS cache 갱신 주기
            //Dns.GetHostEntry("sqlmi-fog-pass-korea.b4ba26535d3d.database.windows.net");
            //Dns.GetHostEntry("sqlmi-fog-pass-korea.secondary.b4ba26535d3d.database.windows.net");

            //DnsUtils.FlushCache();
            //Dns.GetHostEntry(Secret.sqlmi_fog_readwrite_listener.Split(',').GetValue(0).ToString());
            //Dns.GetHostEntry(Secret.sqlmi_fog_readonly_listener.Split(',').GetValue(0).ToString());

            string conn_str = Secret.conn_str_sqlmi_fog_readonly_listener;
            //Console.WriteLine($"conn.ConnectionString = {conn_str.Split(';')?.GetValue(0)?.ToString()}");

            try
            {
                var param = new DynamicParameters();
                param.Add("DealDate", deal.DealDate);
                param.Add("Item", deal.Item.Trim());
                param.Add("UserId", deal.UserId?.ToString());
                param.Add("Amount", deal.Amount);
                param.Add("Tax", deal.Tax);
                param.Add("Note", deal.Note);

                int effected_row = 0;

                using (IDbConnection conn = _context.CreateConnection(conn_str))
                {
                    if (conn.State != ConnectionState.Open) conn.Open();

                    effected_row = conn.Execute(Query.str_command, param);

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
    }
}