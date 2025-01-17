namespace Sork.Tests;
using Sork.Commands;
using Sork.World;
[TestClass]
public sealed class SingCommandsTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        //Arrange
        var command = new SingCommand(new UserInputOutput());
        //Act
        var result = command.Handles("SING");
        //Assert
        Assert.IsTrue(result);
    }
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        //Arrange
        var command = new SingCommand(new UserInputOutput());
        //Act
        var result = command.Handles("sing");
        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        //Arrange
        var io = new TestInputOutput();
        var command = new SingCommand(io);
        var gameState = GameState.Create(io);
        //Act
        var result = command.Execute("SING", gameState);
        //Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(1, io.Outputs.Count);
        Assert.AreEqual("I Love to sing! She recently confessed to me, by the way I have a recording of her lovely singing voice.", io.Outputs[0]);
    }
}