namespace WaterConsumptionTracker.Client.Services.UserService
{
    public interface IUserService
    {
        List<UsersManagement> User { get; set; }
        List<WaterRecords> WaterRecords { get; set; }

        Task GetUsers();

        Task GetWaterRecords();

        Task<UsersManagement> GetSingleUser(int id);

        Task CreateUser(UsersManagement user);

        Task UpdateUser(UsersManagement user);

        Task DeleteUser(int id);

        Task<WaterRecords> GetWaterRecordsforUser(int id);
    }
}
