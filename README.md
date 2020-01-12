# NoRe.Core

 - https://github.com/NoctusRex/NoRe.Core
 - https://www.nuget.org/packages/NoRe.Core/

## Usage
This project contains classes with a general purpose and is used in multiple NoRe projects.
It can also provide you with useful functions:

 - Create XML from objects
 - Create objects from xml
 - Create XML configuration files
 - Pathmanager

## Dependencies

 - .NET Framework 4.8

## Classes
### UML
![uml diagramm](https://raw.githubusercontent.com/NoctusRex/NoRe.Core/master/uml.jpg)
### Description

#### Pathmanager

##### Usage
This static class contains paths to often used directories.
These paths are used by other NoRe-Packages.
Currently the following paths are available:

 - Startup Directory: Returns the directory where the .exe-file is stored/executed.
- Configuration Directory: Returns the directory where all configuration files used by NoRe-Packages will be stored.

**Example:**

> string path = System.IO.Path.Combine(Pathmanager.ConfigurationDirectory, "test.xml");

##### Attributes
 - **public static string StartupDirectory**: Returns the directory where the .exe-file is stored/executed.
 - **public static string ConfigurationDirectory**: Returns the directory where all configuration files used by NoRe-Packages will be stored. If the directory does not exist it is created.

#### XmlConverter
##### Usage
This static class allows to convert objects into xml strings and xml strings back into objects.

**Example:**
> TestConfiguration test = XmlConverter.ConvertXmlToObject< TestConfiguration >(File.ReadAllText(Path));
> string xml = XmlConverter.ConvertObjectToXml(test);
##### Functions

 -  **public static string ConvertObjectToXml(object)**: Converts an object into an readable xml string. Tabs are used to indent and new lines will be created. The string is in UTF-8 encoded.
 - **public static T ConvertXmlToObject<T>(string)**: Converts a xml string into an object. The string needs to be UTF-8 encoded. Use T to specify the target object. 

#### Configuration
##### Usage
This abstract class is the base class for all configurations used by NoRe-Packages.
It allows to convert it self into an xml string and save that string in an external xml file.
This xml file can also be read to restore the properties and attributes of a derived class.

**Example:**

>        public class TestConfiguration : Configuration
>         {
>             public int Integer { get; set; }
>             public string String { get; set; }
>             public decimal Decimal { get; set; }
>             public bool Boolean { get; set; }
>             public DateTime DateTime { get; set; }
>             public TestConfigurationObject TestConfigurationObject { get; set; }
>     
>             public TestConfiguration(string path) : base(path) { }
>             public TestConfiguration() { }
>     
>             public override void Read()
>             {
>                 TestConfiguration tc = Read<TestConfiguration>();
>                 Integer = tc.Integer;
>                 String = tc.String;
>                 Decimal = tc.Decimal;
>                 Boolean = tc.Boolean;
>                 DateTime = tc.DateTime;
>                 TestConfigurationObject = tc.TestConfigurationObject;
>             }
>         }
Note: An empty constructor is needed for (de)serialization.

##### Attributes

 - **public string Path**: This is the path where the configuration file will be written to or read from. This attribute needs to have a valid path before performing reading or writing. Assign the path manually or by using a constructor. 

##### Functions

 - **public Configuration(string)**: Create a derived configuration object and directly assign the configuration path
 - **public Configuration()**: An empty constructor is needed for (de)serialization
 - **protected T Read< T >() where T: Configuration**: This function reads an xml file into an object derived from the Configuration class and throws an exception if Path is not set. If the files does not exists it will be created.
 - **public void Write()**: Writes the derived configuration object into a xml file and throws an exception if Path is not set.
 - **public abstract void Read()**: This function needs to be overriden in order to assign the values of the Read< T >() function and allow for parameter less reading of the a xml file.

