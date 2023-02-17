# Tecnomatix Softwarearchitecture Workshop
Design a Softwarearchitecture for a Tecnomatix Process Simulate Plugin

[ICARUS Consulting GmbH](https://www.icarus-consult.de)

## Environment Variables
To speed up development we introduce some environment variables. We will use these variables to configure our development environment.

To get a direct acces to the `eMPower` directory we add a env variable named `EMPOWER`.

```powershell
# Tecnomatix 2206
[System.Environment]::SetEnvironmentVariable('EMPOWER','C:\Program Files\Tecnomatix\Tecnomatix_2206.0\eMPower')
```

To start Tecnomatix Process Simulate from our IDE we add a env variable which points to the `Tune.exe`.
```powershell
# Tecnomatix 2206
[System.Environment]::SetEnvironmentVariable('TECNOMATIX','C:\Program Files\Tecnomatix\Tecnomatix_2206.0\eMPower\Tune.exe')
```

This enables us to start Tecnomatix Process Simulate from the IDE without introducing a tight coupling to the installed version of Process Simulate.


## Tecnomatix SDK Referencing

We have two ways to reference the Tecnomatix SDK in our projects:
1. Direct Referencing the Dll's 
2. Using Nuget Package Manager (This requires more infrastructure effort since Siemens PLM doesn't provide a Nuget Package for there SDK.)

### Reference by Drive
You can map specific SDK Version to a Drive for instance `Z` like this: 
```cmd
/c subst z: "C:\Program Files\Tecnomatix\Tecnomatix_2206.0\eMPower"
```

You might map additional SDK Version to other drives and switch between the references with different **Build Configurations**.

### Reference by Nuget
Create a Nuget Package from the Tecnoamtix Dll's and push it on a local feed.

## Resources
Resources used to create the content of the workshop.
- [Elegant Objects](https://www.elegantobjects.org)

This list will be completed as soon as possible.

## Open Source Libraries
- [Yaapii.Atoms](https://github.com/icarus-consulting/Yaapii.Atoms) is a collection of object-oriented .NET primitives
- [BriX](https://github.com/icarus-consulting/BriX) OOP printable data structures 
- [MediatR](https://github.com/jbogard/MediatR) Simple mediator implementation in .NET (Strategy Pattern)