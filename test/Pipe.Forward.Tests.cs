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

        [Fact]
        public static async Task PipeAsyncTest()
        {
            //Arrange
            var task = 10.Pipe(i => Task.FromResult(i + 2.5m));

            //Act
            var result = await task;

            //Assert
            Assert.True(task.IsCompleted);
            Assert.Equal(12.5m, result);
        }

        [Fact]
        public void PipeAsyncCancellation()
        {
            //Arrange
            var cancellationToken = new CancellationToken(true);

            async Task<int> cancel(int value, CancellationToken cancellationToken) =>
                await Task.Run(() => value, cancellationToken);

            //Assert
            Assert.ThrowsAsync<TaskCanceledException>(async () => await 0.Pipe(cancel, cancellationToken));
        }

        [Fact]
        public async void PipeAsyncTask()
        {
            //Arrange
            static int timesTen(int value)
                => value * 10;

            //Act
            var result = await Task.Run(() => 10)
                                   .Pipe(timesTen);

            //Assert
            Assert.Equal(100, result);
        }

        [Fact]
        public async void PipeAsyncFromTask()
        {
            //Arrange
            async Task<int> timesTen(int value)
                => await Task.Run(() => value * 10);

            //Act
            var result = await Task.Run(() => 10)
                                   .Pipe(timesTen);

            //Assert
            Assert.Equal(100, result);
        }

        [Fact]
        public async Task PipeAsyncTaskCancellation()
        {
            //Arrange
            var cancellationToken = new CancellationToken(true);

            async Task<int> timesTen(int value, CancellationToken cancellationToken)
                => await Task.Run(() => value * 10, cancellationToken);

            //Assert
            var result = await Assert.ThrowsAsync<TaskCanceledException>(async () => await Task.Run(() => 1).Pipe(timesTen, cancellationToken));
        }
    }
}
