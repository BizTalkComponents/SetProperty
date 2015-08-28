[![Build status](https://ci.appveyor.com/api/projects/status/github/BizTalkComponents/setproperty?branch=master)](https://ci.appveyor.com/api/projects/status/github/BizTalkComponents/setproperty/branch/master)

##Description
Promotes a specified value to a specified property.

This component is useful when you need to promote a hard coded value.

| Parameter       | Description                         | Type| Validation|
| ----------------|-------------------------------------|-----|-----------|
|Property Path|The property path where the specified value will be promoted to, i.e. http://temupuri.org#MyProperty.|String|Required, Format = namespace#property|
|Value|The value that should be promoted to the specified property.|String|Required|
|Promote Property|Specifies whether the property should be promoted or just written to the context.|Bool|Required|


## Remarks ##
Throws ArgumentException if any of the required parameters is not specified.

