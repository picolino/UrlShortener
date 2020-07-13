namespace UrlShortener.Tests.UnitTests.ShortenerService
{
    public class ShortenerServiceTestBase : TestBase
    {
        protected Application.ShortenerService ShortenerService { get; private set; }
        
        protected override void Setup()
        {
            base.Setup();
            
            ShortenerService = new Application.ShortenerService(DatabaseContextStub);
        }
    }
}