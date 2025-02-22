using System;
using OtterGui.Log;

namespace FakeName.OtterGuiHandlers;

public class OtterGuiHandler
{
    public FakeNameFileSystem FakeNameFileSystem;
    public Logger Logger;

    // public AutomationList AutomationList;
    // public Whitelist Whitelist;
    public OtterGuiHandler()
    {
        try
        {
            Logger = new Logger();
            FakeNameFileSystem = new FakeNameFileSystem(this);
            // AutomationList = new();
            // Whitelist = new();
        }
        catch (Exception ex)
        {
            ex.Log();
        }
    }

    public void Dispose()
    {
        Safe(() => FakeNameFileSystem.Save());
        // Safe(() => PresetFileSystem?.Save());
    }
}
