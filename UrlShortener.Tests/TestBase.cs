using NUnit.Framework;
using UrlShortener.DataContext;
using UrlShortener.Tests.Fakes;

namespace UrlShortener.Tests
{
    public class TestBase
    {
        protected DatabaseContextStub DatabaseContextStub { get; private set; }
        
        [SetUp]
        protected virtual void Setup()
        {
            DatabaseContextStub = new DatabaseContextStub();
        }
    }
}