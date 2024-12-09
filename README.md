## Installation (Arch)

### .Net runtime

* yay -S dotnet-host-bin
* yay -S dotnet-runtime-bin
* yay -S dotnet-targeting-pack-bin
* yay -S dotnet-sdk-bin

### ASP.NET Framework

* yay -S aspnet-targeting-pack-bin
* yay -S aspnet-runtime-bin 

## Running

* cd server
* dotnet run

## Verifying
* go to http://localhost:5199/plugin/getall
* verify output

## Development

### Interface

* Implement the `mef.Common.Interfaces.IPlugin` interface.
* Follow `mef.Plugins.Plugins.CollatzPlugin` as example.
* Give your plugin a unique name and ID.

### Input

* Plugins can be called in two ways
  * By ID (byid)
  * By Name (byname)

#### Schema

Input JSON must follow the following schema

```
{
  "$schema": "http://json-schema.org/draft-04/schema#",
  "type": "object",
  "properties": {
    "pluginid": {
      "type": "string"
    },
    "pluginname": {
      "type": "string"
    },
    "parameters": {
      "type": "object",
    }
  },
  "required": ["parameters"],
  "oneOf": [
    {
      "required": ["pluginid"]
    },
    {
      "required": ["pluginname"]
    }
  ]
}
```

## Endpoints

There are three endpoints.

### getall

* http://localhost:5199/plugin/getall
  Returns a list of plugins in format `"plugin name": "plugin id"`

### byid

* http://localhost:5199/plugin/byid
  Run the plugin by ID.

#### Example input

```
{
    "pluginid": "0",
    "parameters": {
        "num": "10"
    }
}
```

### byname

* http://localhost:5199/plugin/byname
  Run the plugin by name.

#### Example input

```
{
    "pluginname": "collatz",
    "parameters": {
        "num": "10"
    }
}
```
