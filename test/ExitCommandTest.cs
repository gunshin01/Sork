namespace Sork.Tests;
using Sork.Commands;
using Sork.World;
[TestClass]
public sealed class ExitCommandsTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        //Arrange
        var command = new ExitCommand(new UserInputOutput());
        //Act
        var result = command.Handles("EXIT");
        //Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        //Arrange
        var command = new ExitCommand(new UserInputOutput());
        //Act
        var result = command.Handles("exit");
        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        //Arrange
        var io = new TestInputOutput();
        var command = new ExitCommand(io);
        var gameState = GameState.Create(io);
        //Act
        var result = command.Execute("EXIT", gameState);
        //Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsTrue(result.RequestExit);
    }
}