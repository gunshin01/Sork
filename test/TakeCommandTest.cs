namespace Sork.Tests;
using Sork.Commands;
using Sork.World;
[TestClass]
public sealed class TakeCommandsTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        //Arrange
        var command = new TakeCommand(new UserInputOutput());
        //Act
        var result = command.Handles("TAKE sword");
        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputError_WhenNoParameters()
    {
        //Arrange
        var io = new TestInputOutput();
        var command = new TakeCommand(io);
        var gameState = GameState.Create(io);
        //Act
        var result = command.Execute("TAKE", gameState);
        //Assert
        Assert.IsFalse(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual("What do you want to take?", io.Outputs[0]);
    }
}
