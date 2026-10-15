# WinUI-File-And-Folder-Picker-Demo

A clean demonstration of **WinUI file/folder picker APIs** with three distinct use cases.

## Three Demo Cases

### **Case 1: FileOpenPicker (Multiple Files)**
- Select multiple files of any type
- Shows selected file names and sizes
- Demonstrates `PickerViewMode.List`

### **Case 2: FolderPicker (Navigate Folder)**
- Select a folder from the file system
- "Browse" button displays folder contents (first 20 items)
- Demonstrates `StorageFolder` enumeration

### **Case 3: Image Picker (PNG & Images Only)**
- Select image files: PNG, JPG, JPEG, BMP, GIF, WEBP
- Restricted file type filter
- `PickerViewMode.Thumbnail` for better preview
- Defaults to `PicturesLibrary`

## Key Features

✅ **WinUI 3 Desktop App**  
✅ **File/Folder Picker APIs** with proper window handle initialization  
✅ **File type filtering** (Case 3)  
✅ **StorageFolder browsing** (Case 2)  
✅ **Clean, card-based UI** with Mica backdrop  

## Project Structure

```
WinUI-FileExplorer-App/
├── App.xaml / App.xaml.cs           (Application bootstrap)
├── MainWindow.xaml / .cs             (Three picker demos)
├── WinUI-FileExplorer-App.csproj     (Project config)
├── Package.appxmanifest              (MSIX manifest)
└── app.manifest                      (Desktop manifest)
```

## MainWindow.xaml Structure

Three cards, each with:
- **Title & Description**
- **Location Row** with TextBox + "..." Button

```xml
<!-- Case 1 Card -->
<Border>
  <TextBlock>Case 1: FileOpenPicker</TextBlock>
  <Grid ColumnDefinitions="*,Auto">
    <TextBox x:Name="Case1LocationTextBox" IsReadOnly="True" />
    <Button Grid.Column="1" Content="..." Click="OpenFilePickerCase1_Click" Background="Transparent" />
  </Grid>
</Border>

<!-- Case 2 Card -->
<!-- Case 3 Card -->
```

## MainWindow.xaml.cs Handlers

```csharp
// Case 1: Multi-file picker (any type)
private async void OpenFilePickerCase1_Click(...)
  → picker.FileTypeFilter.Add("*");
  → await picker.PickMultipleFilesAsync();

// Case 2: Folder picker + browse
private async void OpenFolderPickerCase2_Click(...)
  → await picker.PickSingleFolderAsync();

private async void BrowseFolder_Click(...)
  → StorageFolder.GetItemsAsync();

// Case 3: Image picker (PNG/JPG/BMP/GIF/WEBP)
private async void OpenImagePickerCase3_Click(...)
  → picker.FileTypeFilter.Add(".png");
  → picker.FileTypeFilter.Add(".jpg");
  → // ... etc
```

## Building & Running

```bash
# Build
dotnet build -c Debug

# Run
dotnet run -c Debug

# Direct executable
bin\x64\Debug\net8.0-windows10.0.19041.0\WinUI-FileExplorer-App.exe
```

## Capabilities (Package.appxmanifest)

```xml
<rescap:Capability Name="runFullTrust" />
<rescap:Capability Name="broadFileSystemAccess" />
<uap:Capability Name="documentsLibrary" />
<uap:Capability Name="picturesLibrary" />
<uap:Capability Name="videosLibrary" />
<uap:Capability Name="musicLibrary" />
```

## API Usage Notes

1. **Window Handle Required**
   ```csharp
   var hwnd = WindowNative.GetWindowHandle(this);
   InitializeWithWindow.Initialize(picker, hwnd);
   ```

2. **File Type Filters**
   - `*` = all files
   - `.png`, `.jpg` = specific extensions

3. **Suggested Locations**
   - `PickerLocationId.Desktop`
   - `PickerLocationId.PicturesLibrary`
   - `PickerLocationId.DocumentsLibrary`

4. **View Modes**
   - `PickerViewMode.List` (Case 1)
   - `PickerViewMode.Thumbnail` (Case 3)

## UI Layout

Each case has the same structure:
- **Title** — Case name and description
- **Location Row** — TextBox (path display) + "..." button (transparent)

### Case 1: FileOpenPicker
```
┌─────────────────────────────────────────────────────┐
│ Case 1: FileOpenPicker                              │
│ Select multiple files of any type                   │
│                                                     │
│ Location                                            │
│ ┌───────────────────────────────────┐ ┌──────┐    │
│ │ C:\Users\User\Desktop\file1.txt   │ │ ...  │    │
│ └───────────────────────────────────┘ └──────┘    │
└─────────────────────────────────────────────────────┘
```

### Case 2: FolderPicker
```
┌─────────────────────────────────────────────────────┐
│ Case 2: FolderPicker                                │
│ Select a folder and view its contents               │
│                                                     │
│ Location                                            │
│ ┌───────────────────────────────────┐ ┌──────┐    │
│ │ C:\Users\User\Documents           │ │ ...  │    │
│ └───────────────────────────────────┘ └──────┘    │
└─────────────────────────────────────────────────────┘
```

### Case 3: Image Picker
```
┌─────────────────────────────────────────────────────┐
│ Case 3: Image Picker (PNG/Images Only)              │
│ Select image files (PNG, JPG, BMP, GIF, WEBP)       │
│                                                     │
│ Location                                            │
│ ┌───────────────────────────────────┐ ┌──────┐    │
│ │ C:\Users\User\Pictures\sunset.png │ │ ...  │    │
│ └───────────────────────────────────┘ └──────┘    │
└─────────────────────────────────────────────────────┘
```

## Features

✅ **TextBox Display** — Shows first selected file/folder path  
✅ **Transparent "..." Button** — Clean, minimal design  
✅ **Image Type Filter** — Case 3 restricted to image formats
