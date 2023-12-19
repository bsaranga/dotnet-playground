using InterviewPracticeCode.DataStructures.LinkedLists;

namespace InterviewPracticeCodeTests
{
    [TestFixture]
    public class SinglyLinkedListTest
    {
        [Test]
        public void PushAndPop_Success()
        {
            // Arrange
            var sll = new SinglyLinkedList<int>();

            // Act
            sll.Push(1);
            sll.Push(2);
            sll.Push(3);

            // Assert
            Assert.That(sll.Pop(), Is.EqualTo(3));
            Assert.That(sll.Pop(), Is.EqualTo(2));
            Assert.That(sll.Pop(), Is.EqualTo(1));
        }

        [Test]
        public void AddAndPop_Success()
        {
            // Arrange
            var sll = new SinglyLinkedList<int>();

            // Act
            sll.Add(1);
            sll.Add(2);
            sll.Add(3);

            // Assert
            Assert.That(sll.Pop(), Is.EqualTo(1));
            Assert.That(sll.Pop(), Is.EqualTo(2));
            Assert.That(sll.Pop(), Is.EqualTo(3));
        }

    }
}
