namespace LearningCourseApp.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(int id, string courseName,string courseDescription,string price);
    }
}
