using System;
using NUnit.Framework;

namespace TestProject7
{
    [TestFixture]
    public class Tests
    {
 [Test]
 public void SortArray_WithNormalArray_ReturnsSortedArray()
 {
     int[] input = { 5, 2, 8, 1, 9 };
     int[] expected = { 1, 2, 5, 8, 9 };
     int[] result = Lab1.SortArray(input);
     Assert.AreEqual(expected, result);
 }
 
 [Test]
 public void SortArray_WithEmptyArray_ReturnsEmptyArray()
 {
     int[] input = { };
     int[] result = Lab1.SortArray(input);
     Assert.AreEqual(0, result.Length);
 }
 
 [Test]
 public void SortArray_WithSingleElement_ReturnsSameArray()
 {
     int[] input = { 42 };
     int[] result = Lab1.SortArray(input);
     Assert.AreEqual(input, result);
 }
 
 [Test]
 public void SortArray_WithNullArray_ThrowsArgumentNullException()
 {
     Assert.Throws<ArgumentNullException>(() => Lab1.SortArray(null));
 }
 
 [Test]
 public void SortArray_WithNegativeNumbers_ReturnsSortedArray()
 {
     int[] input = { -3, -1, -5, 0, 2 };
     int[] expected = { -5, -3, -1, 0, 2 };
     int[] result = Lab1.SortArray(input);
     Assert.AreEqual(expected, result);
 }
 
 // 1.2. Тесты для проверки палиндрома
 [Test]
 public void IsPalindrome_WithPalindrome_ReturnsTrue()
 {
     Assert.IsTrue(Lab1.IsPalindrome("A man a plan a canal Panama"));
 }
 
 [Test]
 public void IsPalindrome_WithNonPalindrome_ReturnsFalse()
 {
     Assert.IsFalse(Lab1.IsPalindrome("Hello World"));
 }
 
 [Test]
 public void IsPalindrome_WithEmptyString_ReturnsTrue()
 {
     Assert.IsTrue(Lab1.IsPalindrome(""));
 }
 
 [Test]
 public void IsPalindrome_WithNull_ThrowsArgumentNullException()
 {
     Assert.Throws<ArgumentNullException>(() => Lab1.IsPalindrome(null));
 }
 
 [Test]
 public void IsPalindrome_WithSingleCharacter_ReturnsTrue()
 {
     Assert.IsTrue(Lab1.IsPalindrome("a"));
 }
 
 // 1.3. Тесты для вычисления факториала
 [Test]
 public void Factorial_WithZero_ReturnsOne()
 {
     Assert.AreEqual(1, Lab1.Factorial(0));
 }
 
 [Test]
 public void Factorial_WithPositiveNumber_ReturnsCorrectValue()
 {
     Assert.AreEqual(120, Lab1.Factorial(5));
 }
 
 [Test]
 public void Factorial_WithNegativeNumber_ThrowsArgumentException()
 {
     Assert.Throws<ArgumentException>(() => Lab1.Factorial(-1));
 }
 
 [Test]
 public void Factorial_WithLargeNumber_ThrowsArgumentException()
 {
     Assert.Throws<ArgumentException>(() => Lab1.Factorial(21));
 }
 
 // 1.4. Тесты для чисел Фибоначчи
 [Test]
 public void Fibonacci_WithZero_ReturnsZero()
 {
     Assert.AreEqual(0, Lab1.Fibonacci(0));
 }
 
 [Test]
 public void Fibonacci_WithFirstPosition_ReturnsOne()
 {
     Assert.AreEqual(1, Lab1.Fibonacci(1));
 }
 
 [Test]
 public void Fibonacci_WithTenthPosition_ReturnsCorrectValue()
 {
     Assert.AreEqual(55, Lab1.Fibonacci(10));
 }
 
 [Test]
 public void Fibonacci_WithNegativePosition_ThrowsArgumentException()
 {
     Assert.Throws<ArgumentException>(() => Lab1.Fibonacci(-1));
 }
 
 // 1.5. Тесты для поиска подстроки
 [Test]
 public void FindSubstring_WithExistingSubstring_ReturnsCorrectIndex()
 {
     Assert.AreEqual(6, Lab1.FindSubstring("Hello World", "World"));
 }
 
 [Test]
 public void FindSubstring_WithNonExistingSubstring_ReturnsMinusOne()
 {
     Assert.AreEqual(-1, Lab1.FindSubstring("Hello World", "Test"));
 }
 
 [Test]
 public void FindSubstring_WithEmptySubstring_ReturnsZero()
 {
     Assert.AreEqual(0, Lab1.FindSubstring("Hello World", ""));
 }
 
 [Test]
 public void FindSubstring_WithNullText_ThrowsArgumentNullException()
 {
     Assert.Throws<ArgumentNullException>(() => Lab1.FindSubstring(null, "test"));
 }
 
 // 1.6. Тесты для проверки простого числа
 [Test]
 public void IsPrime_WithPrimeNumber_ReturnsTrue()
 {
     Assert.IsTrue(Lab1.IsPrime(17));
 }
 
 [Test]
 public void IsPrime_WithNonPrimeNumber_ReturnsFalse()
 {
     Assert.IsFalse(Lab1.IsPrime(15));
 }
 
 [Test]
 public void IsPrime_WithOne_ReturnsFalse()
 {
     Assert.IsFalse(Lab1.IsPrime(1));
 }
 
 [Test]
 public void IsPrime_WithTwo_ReturnsTrue()
 {
     Assert.IsTrue(Lab1.IsPrime(2));
 }
 
 // 1.7. Тесты для реверса числа
 [Test]
 public void ReverseNumber_WithPositiveNumber_ReturnsReversed()
 {
     Assert.AreEqual(321, Lab1.ReverseNumber(123));
 }
 
 [Test]
 public void ReverseNumber_WithNegativeNumber_ReturnsReversedWithSign()
 {
     Assert.AreEqual(-21, Lab1.ReverseNumber(-120));
 }
 
 [Test]
 public void ReverseNumber_WithOverflow_ReturnsZero()
 {
     Assert.AreEqual(0, Lab1.ReverseNumber(1234567899));
 }
 
 [Test]
 public void ReverseNumber_WithZero_ReturnsZero()
 {
     Assert.AreEqual(0, Lab1.ReverseNumber(0));
 }
 
 // 1.8. Тесты для римских чисел
 [Test]
 public void ToRomanNumeral_WithValidNumber_ReturnsCorrectRoman()
 {
     Assert.AreEqual("XIV", Lab1.ToRomanNumeral(14));
 }
 
 [Test]
 public void ToRomanNumeral_WithOne_ReturnsI()
 {
     Assert.AreEqual("I", Lab1.ToRomanNumeral(1));
 }
 
 [Test]
 public void ToRomanNumeral_WithLargeNumber_ReturnsCorrectRoman()
 {
     Assert.AreEqual("MMMCMXCIX", Lab1.ToRomanNumeral(3999));
 }
 
 [Test]
 public void ToRomanNumeral_WithZero_ThrowsArgumentOutOfRangeException()
 {
     Assert.Throws<ArgumentOutOfRangeException>(() => Lab1.ToRomanNumeral(0));
 }
 
 [Test]
 public void ToRomanNumeral_WithNegativeNumber_ThrowsArgumentOutOfRangeException()
 {
     Assert.Throws<ArgumentOutOfRangeException>(() => Lab1.ToRomanNumeral(-5));
 }
    }
}