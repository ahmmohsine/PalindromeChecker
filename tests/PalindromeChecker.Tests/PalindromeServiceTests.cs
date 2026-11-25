using PalindromeChecker.Core;

namespace PalindromeChecker.Tests;

public class PalindromeServiceTests
{
    private readonly IPalindromeService _service = new PalindromeService();
    [Theory]
    [InlineData("kayak")]
    [InlineData("aa")]
    public void IsPalindrome_IsWordPalindrome_ReturnsTrue(string word)
    {
        // Act
        var result = _service.IsPalindrome(word);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("pomme")]
    public void IsPalindrome_IsNotPalindrome_ReturnsFalse(string word)
    {
        // Act
        var result = _service.IsPalindrome(word);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("Ésope reste ici et se repose.")]
    [InlineData("Engage le jeu que je le gagne.")]
    [InlineData("La mariée ira mal.")]
    [InlineData("Eh ! ça va la vache ?")]
    public void IsPalindrome_PalindromeSentence_ReturnsTrue(string sentence)
    {
        var result = _service.IsPalindrome(sentence);
        Assert.True(result);
    }

    [Theory]
    [InlineData("Ésope reste ici.")]
    [InlineData("Engage le jeu.")]
    [InlineData("La mariée.")]
    [InlineData("ça va la vache ?")]
    public void IsPalindrome_NotPalindromeSentence_ReturnsFalse(string sentence)
    {
        var result = _service.IsPalindrome(sentence);
        Assert.False(result);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("!!!")]
    public void IsPalindrome_NoLetters_ReturnsFalse(string word)
    {
        var result = _service.IsPalindrome(word);
        Assert.False(result);
    }

    [Fact]
    public void IsPalindrome_IsSingleLetter_ReturnsTrue()
    {
        var result = _service.IsPalindrome("a");
        Assert.True(result);
    }

    [Theory]
    [InlineData("KAYAK")]
    [InlineData("aA")]
    public void IsPalindrome_UppercaseWord_ReturnsTrue(string word)
    {
        // Act
        var result = _service.IsPalindrome(word);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_Null_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _service.IsPalindrome(null!));
    }

}
