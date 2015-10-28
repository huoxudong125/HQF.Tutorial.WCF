#Version Tolerant Serialization(版本兼容序列化)

Version Tolerant Serialization (VTS) is a set of features **introduced in .NET Framework 2.0** that makes it easier, over time, to modify serializable types. Specifically, the VTS features are enabled for classes to which the SerializableAttribute attribute has been applied, including generic types. VTS makes it possible to add new fields to those classes without breaking compatibility with other versions of the type. For a working sample application, see Version Tolerant Serialization Technology Sample.

```c#
    // Version 1.0
    [Serializable]
    public class Person
    {
        public string FullName;
    }
    
    // Version 2.0
    [Serializable]
    public class Person
    {
        public string FullName;
    
        [OptionalField(VersionAdded = 2)]
        public string NickName;
        [OptionalField(VersionAdded = 2)]
        public DateTime BirthDate;
    }
    
    // Version 3.0
    [Serializable]
    public class Person
    {
        public string FullName;
    
        [OptionalField(VersionAdded=2)]
        public string NickName;
        [OptionalField(VersionAdded=2)]
        public DateTime BirthDate;
    
        [OptionalField(VersionAdded=3)]
        public int Weight;
    }
``` 
More info to reference  https://msdn.microsoft.com/en-us/library/ms229752(v=vs.110).aspx 