# Utils.Dialog
Nice message dialog and input dialog

## Usage

### Message dialog
```csharp
// Shows a simple text message with "OK" button.
MessageResult result = MessageDialog.Show("Text message");

// Shows a simple text message with a caption, "OK" and "Cancel" button and information icon.
MessageResult result = MessageDialog.Show("Text message", "Caption", MessageButtons.OKCancel, MessageIcon.Information);

// Shows a multiline text message.
MessageResult result = MessageDialog.Show(new string[] {
    "Text message line 1", 
    "Text message line 2", 
    "Text message line 3", 
});

// Shows a multiline text message with format information.
MessageResult result = MessageDialog.Show(new string[] {
    "This message dialog function supports <b>bold</b>, <i>italic</i> and <u>underlined</u> text.", 
    "You also can <b><i>combine</i></b> format information like in html.", 
    "Lists can be formatted with tabulators and line breaks like this:", 
    "<t>1. First<p><t>2. Second<p><t>3. Third",
    "Hyperlinks are supported too: https//github.com"
});
```

### Message dialog
```csharp
// Shows a simple text message with "OK" button.
MessageResult result = MessageDialog.Show("Text message");

// Shows a simple text message with a caption, "OK" and "Cancel" button and information icon.
MessageResult result = MessageDialog.Show("Text message", "Caption", MessageButtons.OKCancel, MessageIcon.Information);
```
### Message dialog with autoclose
```csharp
// Shows a simple text message with "Close" button, succes icon and autoclose after 5 seconds.
MessageResult result = MessageDialog.Show("Text message", MessageButtons.Close, MessageIcon.Success, 5);
```

### Message dialog without buttons (has to be closed by calling form)
```csharp
// Shows a simple text message with information icon and without buttons. (No result!)
MessageDialog.Show("Text message", MessageButtons.None, MessageIcon.Information);
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
