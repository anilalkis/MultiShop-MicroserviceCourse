using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;
        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code",createCouponDto.Code);
            parameters.Add("@rate",createCouponDto.Rate);
            parameters.Add("@isActive",createCouponDto.IsActive);
            parameters.Add("@validDate",createCouponDto.ValidDate);
            using(var con = _context.CreateConnection()) 
            {
                await con.ExecuteAsync(query,parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "delete from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using( var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query,parameters );
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "select * from Coupons";
            using(var con = _context.CreateConnection()) 
            {
                var values = await con.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "select from Coupons where CouponId=@couponId";
            var parameters= new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var con = _context.CreateConnection())
            {
                var value = await con.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return value;
            }
        }

        public async Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "select * from Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using(var con = _context.CreateConnection()) 
            {
                var values = await con.QueryFirstOrDefaultAsync<ResultDiscountCouponDto?>(query,parameters);
                return values;
            }
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            string query = "select Rate from Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var con = _context.CreateConnection())
            {
                var values = await con.QueryFirstOrDefaultAsync<int>(query, parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateCouponDto.CouponId);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, parameters);
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "Select Count(*) From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }
    }
}
