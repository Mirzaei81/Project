using Xunit.Abstractions;
namespace ArrayList.Test;

public class UnitTest1 
{
    public class FulledArrListTest : IDisposable
    {
        private ArrayListObj<int>  _arrayList;
        private readonly ITestOutputHelper  _output;
        public FulledArrListTest(ITestOutputHelper output)
        {
            ArrayListObj<int> arrayList = new();
            for(int i=0;i<10;i++)
            {
                arrayList.add(i);
            }
            _arrayList = arrayList;
            _output = output;
        }

        public void Dispose()
        {
            _arrayList.clean();
        }

        [Fact]
        public void Adding()
        {
            string actual ="";
            for(int i=0;i<10;i++)
            {
                actual+=$"{i} ";
            }
            Assert.Equal(actual,_arrayList.ToString());
            Assert.Equal(10,_arrayList.size);
            Assert.Equal(10,_arrayList.count);
        }

        [Fact]
        public void resizing()
        {
            _arrayList.add(11);
            Assert.NotEqual(10,_arrayList.size);
            Assert.Equal(20,_arrayList.size);
            _output.WriteLine(_arrayList.size.ToString()); 
            _arrayList.remove(4);
            _output.WriteLine(_arrayList.size.ToString()); 
            Assert.NotEqual(20,_arrayList.size);
            Assert.Equal(10,_arrayList.size);

        }

        [Fact]
        public void remove()
        {
            _arrayList.remove(5);
            Assert.Equal(9,_arrayList.count);
            Assert.Equal(10,_arrayList.size);

        }
        [Fact]
        public void insert()
        {
            _arrayList.insert(5,22);
            Assert.Equal(11,_arrayList.count);
            Assert.Equal(20,_arrayList.size);

        }
    }
}
