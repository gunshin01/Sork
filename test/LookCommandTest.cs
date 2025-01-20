namespace Sork.Tests;
using Sork.Commands;
using Sork.World;

[TestClass]
public sealed class LookCommandTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        //Arrange
        var command = new LookCommand(new TestInputOutput());
        //Act
        var result = command.Handles("LOOK");
        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputLocationDescription()
    {
        //Arrange
        var io = new TestInputOutput();
        var command = new LookCommand(io);
        var gameState = GameState.Create(io);
        //Act
        var result = command.Execute("LOOK", gameState);
        //Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(2, io.Outputs.Count);
        Assert.AreEqual(gameState.Player.Location.Description, io.Outputs[0]);
        Assert.AreEqual("You are carrying: Sword", io.Outputs[1]);
    }

    [TestMethod] 
    public void Handle_ShouldReturnTrue_WhenInputIsLowerCase()
    {
        //Arrange
        var command = new LookCommand(new TestInputOutput());
        //Act
        var result = command.Handles("look");
        //Assert
        Assert.IsTrue(result);
    }
}
