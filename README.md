# Unity Binary File Saver

Very basic binary saving / loading functionality for Unity.

## How to use

Save data by creating a class which implements the blank `ISaveContainer` interface.
Store any serializable classes or properties in your new ISaveContainer class.

- `Assets/Examples/Scripts/GameSaveContainer.cs` example `ISaveContainer` implementation.
- `Assets/Examples/Scripts/Example.cs` saving / loading example.

### Serialization issues

If you see the following error

`SerializationException: Type <Foo> is not marked as Serializable`

this means you are attempting to serialize an object which is not serializable.
You would see this message when trying to save a GameObject for example. An easy
workaround is to mark this as a non-serialized object:

    [NonSerialized]
    public GameObject foobar;

See `Assets/Examples/Scripts/GameSaveContainer.cs` for an example
