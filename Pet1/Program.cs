namespace Pet1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ///TODO: ������������� ��������.
            

            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.Run();
        }
    }
}
