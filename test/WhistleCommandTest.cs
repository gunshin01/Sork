namespace Sork.Tests;
using Sork.Commands;
using Sork.World;
[TestClass]
public sealed class WhistleCommandsTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        //Arrange
        var command = new WhistleCommand(new UserInputOutput());
        //Act
        var result = command.Handles("WHISTLE");
        //Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        //Arrange
        var command = new WhistleCommand(new UserInputOutput());
        //Act
        var result = command.Handles("whistle");
        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        //Arrange
        var io = new TestInputOutput();
        var command = new WhistleCommand(io);
        var gameState = GameState.Create(io);
        //Act
        var result = command.Execute("WHISTLE", gameState);
        //Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual("Come on somebody, why don't you run? Ol'Reds itching to have a little fun!", io.Outputs[0]);
    }
}