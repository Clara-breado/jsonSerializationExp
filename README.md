# jsonSerializationExp
## Refference:
https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/#how-source-generation-provides-benefits
https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonsourcegenerationmode?view=net-7.0

## Exepriments:
##### Current Serializer/Desirializer: Newtonsoft.Json.JsonConvert => SerializeObject/DeserializeObject
##### Classic Serializer/Desirializer: System.Text.Json.JsonSerializer => Serialize/Deserialize
##### Generated (Default) Serializer/Desirializer: System.Text.Json.JsonSerializer => Serialize/Deserialize + JsonSourceGenerationMode.Default
##### Generated Metadata Serializer/Desirializer: System.Text.Json.JsonSerializer => Serialize/Deserialize + JsonSourceGenerationMode.Metadata
##### Generated Serialization Serializer/Desirializer: System.Text.Json.JsonSerializer => Serialize/Deserialize + JsonSourceGenerationMode.Serialization

## Results:
### Serialization
![image](https://user-images.githubusercontent.com/52954733/197736698-0d6a97bb-6f3b-4c9d-9190-49f5d4ca048d.png)
### Deserialization
![image](https://user-images.githubusercontent.com/52954733/197736909-c27aac38-a3e6-444e-b926-6c70c8d82b4d.png)
