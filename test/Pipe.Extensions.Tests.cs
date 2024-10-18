namespace Moonad.Pipe.Tests
{
    public class PipeExtensionsTests
    {
        [Fact]
        public void Pipe()
        {
            //Act
            var result = 10.Pipe(i => $"O número selecionado foi {i}.");

            //Assert
            Assert.Equal("O número selecionado foi 10.", result);
        }

        [Fact]
        public void PipeWithAction()
        {
            //Arrange
            bool on = true;
            void TurnOff() => on = false;

            //Act
            on.Pipe(i => TurnOff());

            //Assert
            Assert.False(on);
        }
    }
}
