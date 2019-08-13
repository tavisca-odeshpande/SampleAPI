using System;
using Xunit;
using SampleAPI.Controllers;

namespace ApiTests
{
    public class ControllerFixture
    {
        [Fact]
        public void hello_controller_noinput_tests()
        {
            HelloController hello = new HelloController();
            Assert.Equal("Hi", hello.Get().Value);
        }

        [Fact]
        public void hello_controller_nameinput_tests()
        {
            HelloController hello = new HelloController();
            Assert.Equal("Hi Raunak", hello.Get("Raunak").Value);
        }

        [Fact]
        public void hi_controller_noinput_tests()
        {
            HiController hi = new HiController();
            Assert.Equal("Say hello",hi.Get().Value);
        }

        [Fact]
        public void hi_controller_nameinput_tests()
        {
            HiController hi = new HiController();
            Assert.Equal("Raunak Say hello", hi.Get("Raunak").Value);
        }
    }
}
