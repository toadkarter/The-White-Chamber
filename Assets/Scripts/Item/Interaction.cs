using System;

// Source: https://stackoverflow.com/questions/29442329/serializing-a-dictionary-in-c-sharp
// Very clever way of serializing a dictionary!
[Serializable]
public struct Interaction
{
    public int itemId;
    public string response;
}
