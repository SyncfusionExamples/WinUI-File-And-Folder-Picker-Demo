using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Storage.Pickers;
using WinRT.Interop;

namespace WinUI_FileExplorer_App
{
    public sealed partial class MainWindow : Window
    {
        private StorageFolder? _selectedFolder;

        public MainWindow()
        {
            InitializeComponent();
        }

        // ===== CASE 1: FileOpenPicker (Multiple Files, Any Type) =====
        private async void OpenFilePickerCase1_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            var hwnd = WindowNative.GetWindowHandle(this);
            InitializeWithWindow.Initialize(picker, hwnd);

            picker.ViewMode = PickerViewMode.List;
            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.FileTypeFilter.Add("*");

            var files = await picker.PickMultipleFilesAsync();
            if (files?.Count > 0)
            {
                // Show first file path in textbox
                Case1LocationTextBox.Text = files.First().Path;

            }
        }

        // ===== CASE 2: FolderPicker (Select & Navigate) =====
        private async void OpenFolderPickerCase2_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FolderPicker();
            var hwnd = WindowNative.GetWindowHandle(this);
            InitializeWithWindow.Initialize(picker, hwnd);

            picker.SuggestedStartLocation = PickerLocationId.Desktop;
            picker.FileTypeFilter.Add("*");

            var folder = await picker.PickSingleFolderAsync();
            if (folder != null)
            {
                _selectedFolder = folder;
                
                // Display path in textbox
                Case2LocationTextBox.Text = folder.Path;

            }
        }

        // ===== CASE 3: Image Picker (PNG, JPG, BMP, GIF, WEBP Only) =====
        private async void OpenImagePickerCase3_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            var hwnd = WindowNative.GetWindowHandle(this);
            InitializeWithWindow.Initialize(picker, hwnd);

            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            
            // Add image file type filters
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".bmp");
            picker.FileTypeFilter.Add(".gif");
            picker.FileTypeFilter.Add(".webp");

            var files = await picker.PickMultipleFilesAsync();
            if (files?.Count > 0)
            {
                // Show first image path in textbox
                Case3LocationTextBox.Text = files.First().Path;

            }
        }

    }
}
