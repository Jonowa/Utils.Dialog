# Utils.Dialog
Nice message dialog and input dialog

## Usage

### Message dialog
```csharp
// Shows a simple text message with "OK" button.
MessageResult result = MessageDialog.Show("Text massage");

// Shows a simple text message with a caption, "OK" and "Cancel" button and information icon.
MessageResult result = MessageDialog.Show("Text massage", "Caption", MessageButtons.OKCancel, MessageIcon.Information);
```

### Message dialog with autoclose
```csharp
// Shows a simple text message with "Close" button, succes icon and autoclose after 5 seconds.
MessageResult result = MessageDialog.Show("Text massage", MessageButtons.Close, MessageIcon.Success, 5);
```

### Message dialog without buttons (has to be closed by calling form)
```csharp
// Shows a simple text message with information icon and without buttons. (No result!)
MessageDialog.Show("Text massage", MessageButtons.None, MessageIcon.Information);
// Close message
MessageDialog.Close();
```

### Input dialog
```csharp
// Shows a simple input dialog.
string input = MessageDialog.Input("Please enter your name.");

// Shows a simple input dialog with default value.
string input = MessageDialog.Input("Please enter your name.", "John Doe");

// Shows a input dialog with additional "Cancel" button an multiline support.
string input = MessageDialog.Input("Please enter your name.", true, MessageButtons.OKCancel);
```
