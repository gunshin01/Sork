namespace Sork.Tests;
using Sork.Commands;
using Sork.World;
[TestClass]
public sealed class DanceCommandsTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        //Arrange
        var command = new DanceCommand(new UserInputOutput());
        //Act
        var result = command.Handles("DANCE");
        //Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        //Arrange
        var command = new DanceCommand(new UserInputOutput());
        //Act
        var result = command.Handles("dance");
        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        //Arrange
        var io = new TestInputOutput();
        var command = new DanceCommand(io);
        var gameState = GameState.Create(io);
        //Act
        var result = command.Execute("DANCE", gameState);
        //Assert
        Assert.IsFalse(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(2, io.Outputs.Count);
        Assert.AreEqual("You", io.Outputs[0]);
        Assert.AreEqual(" Dance!", io.Outputs[1]);
    }
}
