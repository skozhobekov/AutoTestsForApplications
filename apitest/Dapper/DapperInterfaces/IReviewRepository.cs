using apitest.Dapper.DapperDto;

namespace apitest.Dapper.DapperInterfaces;

public interface IReviewRepository
{
    Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync();
}