# Aspose.Psd.Cloud.Sdk.Api.PsdApi

<a name="copyfile"></a>
## **CopyFile**
> void CopyFile(CopyFileRequest request)

Copy file

### **CopyFileRequest** Parameters
```csharp
CopyFileRequest(
    string srcPath, 
    string destPath, 
    string srcStorageName = null, 
    string destStorageName = null, 
    string versionId = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **srcPath** | **string**| Source file path e.g. &#39;/folder/file.ext&#39; | 
 **destPath** | **string**| Destination file path | 
 **srcStorageName** | **string**| Source storage name | [optional] 
 **destStorageName** | **string**| Destination storage name | [optional] 
 **versionId** | **string**| File version ID to copy | [optional] 

### Return type

void (empty response body)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="copyfolder"></a>
## **CopyFolder**
> void CopyFolder(CopyFolderRequest request)

Copy folder

### **CopyFolderRequest** Parameters
```csharp
CopyFolderRequest(
    string srcPath, 
    string destPath, 
    string srcStorageName = null, 
    string destStorageName = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **srcPath** | **string**| Source folder path e.g. &#39;/src&#39; | 
 **destPath** | **string**| Destination folder path e.g. &#39;/dst&#39; | 
 **srcStorageName** | **string**| Source storage name | [optional] 
 **destStorageName** | **string**| Destination storage name | [optional] 

### Return type

void (empty response body)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="createcroppedimage"></a>
## **CreateCroppedImage**
> System.IO.Stream CreateCroppedImage(CreateCroppedImageRequest request)

Crop an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.

### **CreateCroppedImageRequest** Parameters
```csharp
CreateCroppedImageRequest(
    System.IO.Stream imageData, 
    int? x, 
    int? y, 
    int? width, 
    int? height, 
    string format = null, 
    string outPath = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageData** | **System.IO.Stream**| Input image | 
 **x** | **int?**| X position of start point for cropping rectangle. | 
 **y** | **int?**| Y position of start point for cropping rectangle. | 
 **width** | **int?**| Width of cropping rectangle. | 
 **height** | **int?**| Height of cropping rectangle. | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | [optional] 
 **outPath** | **string**| Path to updated file (if this is empty, response contains streamed image). | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="createdeskewedimage"></a>
## **CreateDeskewedImage**
> System.IO.Stream CreateDeskewedImage(CreateDeskewedImageRequest request)

Deskew an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.

### **CreateDeskewedImageRequest** Parameters
```csharp
CreateDeskewedImageRequest(
    System.IO.Stream imageData, 
    bool? resizeProportionally, 
    string bkColor = null, 
    string outPath = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageData** | **System.IO.Stream**| Input image | 
 **resizeProportionally** | **bool?**| Resize proportionally | 
 **bkColor** | **string**| Background color | [optional] 
 **outPath** | **string**| Path to updated file (if this is empty, response contains streamed image) | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="createfolder"></a>
## **CreateFolder**
> void CreateFolder(CreateFolderRequest request)

Create the folder

### **CreateFolderRequest** Parameters
```csharp
CreateFolderRequest(
    string path, 
    string storageName = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **path** | **string**| Folder path to create e.g. &#39;folder_1/folder_2/&#39; | 
 **storageName** | **string**| Storage name | [optional] 

### Return type

void (empty response body)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="creategrayscaledimage"></a>
## **CreateGrayscaledImage**
> System.IO.Stream CreateGrayscaledImage(CreateGrayscaledImageRequest request)

Grayscales an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.

### **CreateGrayscaledImageRequest** Parameters
```csharp
CreateGrayscaledImageRequest(
    System.IO.Stream imageData, 
    string outPath = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageData** | **System.IO.Stream**| Input image | 
 **outPath** | **string**| Path to updated file (if this is empty, response contains streamed image) | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="createmodifiedpsd"></a>
## **CreateModifiedPsd**
> System.IO.Stream CreateModifiedPsd(CreateModifiedPsdRequest request)

Update parameters of PSD image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.

### **CreateModifiedPsdRequest** Parameters
```csharp
CreateModifiedPsdRequest(
    System.IO.Stream imageData, 
    int? channelsCount = null, 
    string compressionMethod = null, 
    bool? fromScratch = null, 
    string outPath = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageData** | **System.IO.Stream**| Input image | 
 **channelsCount** | **int?**| Count of color channels. | [optional] [default to 4]
 **compressionMethod** | **string**| Compression method (for now, raw and RLE are supported). | [optional] [default to rle]
 **fromScratch** | **bool?**| Specifies where additional parameters we do not support should be taken from. If this is true – they will be taken from default values for standard image, if it is false – they will be saved from current image. Default is false. | [optional] [default to false]
 **outPath** | **string**| Path to updated file (if this is empty, response contains streamed image). | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="createresizedimage"></a>
## **CreateResizedImage**
> System.IO.Stream CreateResizedImage(CreateResizedImageRequest request)

Resize an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.

### **CreateResizedImageRequest** Parameters
```csharp
CreateResizedImageRequest(
    System.IO.Stream imageData, 
    int? newWidth, 
    int? newHeight, 
    string format = null, 
    string outPath = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageData** | **System.IO.Stream**| Input image | 
 **newWidth** | **int?**| New width. | 
 **newHeight** | **int?**| New height. | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | [optional] 
 **outPath** | **string**| Path to updated file (if this is empty, response contains streamed image). | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="createrotateflippedimage"></a>
## **CreateRotateFlippedImage**
> System.IO.Stream CreateRotateFlippedImage(CreateRotateFlippedImageRequest request)

Rotate and/or flip an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.

### **CreateRotateFlippedImageRequest** Parameters
```csharp
CreateRotateFlippedImageRequest(
    System.IO.Stream imageData, 
    string method, 
    string format = null, 
    string outPath = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageData** | **System.IO.Stream**| Input image | 
 **method** | **string**| RotateFlip method (Rotate180FlipNone, Rotate180FlipX, Rotate180FlipXY, Rotate180FlipY, Rotate270FlipNone, Rotate270FlipX, Rotate270FlipXY, Rotate270FlipY, Rotate90FlipNone, Rotate90FlipX, Rotate90FlipXY, Rotate90FlipY, RotateNoneFlipNone, RotateNoneFlipX, RotateNoneFlipXY, RotateNoneFlipY). | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | [optional] 
 **outPath** | **string**| Path to updated file (if this is empty, response contains streamed image). | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="createsavedimageas"></a>
## **CreateSavedImageAs**
> System.IO.Stream CreateSavedImageAs(CreateSavedImageAsRequest request)

Export existing image to another format. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.             

### **CreateSavedImageAsRequest** Parameters
```csharp
CreateSavedImageAsRequest(
    System.IO.Stream imageData, 
    string format, 
    string outPath = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageData** | **System.IO.Stream**| Input image | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | 
 **outPath** | **string**| Path to updated file (if this is empty, response contains streamed image). | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="createupdatedimage"></a>
## **CreateUpdatedImage**
> System.IO.Stream CreateUpdatedImage(CreateUpdatedImageRequest request)

Perform scaling, cropping and flipping of an image in a single request. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.

### **CreateUpdatedImageRequest** Parameters
```csharp
CreateUpdatedImageRequest(
    System.IO.Stream imageData, 
    int? newWidth, 
    int? newHeight, 
    int? x, 
    int? y, 
    int? rectWidth, 
    int? rectHeight, 
    string rotateFlipMethod, 
    string format = null, 
    string outPath = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageData** | **System.IO.Stream**| Input image | 
 **newWidth** | **int?**| New width of the scaled image. | 
 **newHeight** | **int?**| New height of the scaled image. | 
 **x** | **int?**| X position of start point for cropping rectangle. | 
 **y** | **int?**| Y position of start point for cropping rectangle. | 
 **rectWidth** | **int?**| Width of cropping rectangle. | 
 **rectHeight** | **int?**| Height of cropping rectangle. | 
 **rotateFlipMethod** | **string**| RotateFlip method (Rotate180FlipNone, Rotate180FlipX, Rotate180FlipXY, Rotate180FlipY, Rotate270FlipNone, Rotate270FlipX, Rotate270FlipXY, Rotate270FlipY, Rotate90FlipNone, Rotate90FlipX, Rotate90FlipXY, Rotate90FlipY, RotateNoneFlipNone, RotateNoneFlipX, RotateNoneFlipXY, RotateNoneFlipY). Default is RotateNoneFlipNone. | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | [optional] 
 **outPath** | **string**| Path to updated file (if this is empty, response contains streamed image). | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="cropimage"></a>
## **CropImage**
> System.IO.Stream CropImage(CropImageRequest request)

Crop an existing image.

### **CropImageRequest** Parameters
```csharp
CropImageRequest(
    string name, 
    int? x, 
    int? y, 
    int? width, 
    int? height, 
    string format = null, 
    string folder = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Filename of an image. | 
 **x** | **int?**| X position of start point for cropping rectangle. | 
 **y** | **int?**| Y position of start point for cropping rectangle. | 
 **width** | **int?**| Width of cropping rectangle | 
 **height** | **int?**| Height of cropping rectangle. | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | [optional] 
 **folder** | **string**| Folder with image to process. | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="deletefile"></a>
## **DeleteFile**
> void DeleteFile(DeleteFileRequest request)

Delete file

### **DeleteFileRequest** Parameters
```csharp
DeleteFileRequest(
    string path, 
    string storageName = null, 
    string versionId = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **path** | **string**| File path e.g. &#39;/folder/file.ext&#39; | 
 **storageName** | **string**| Storage name | [optional] 
 **versionId** | **string**| File version ID to delete | [optional] 

### Return type

void (empty response body)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="deletefolder"></a>
## **DeleteFolder**
> void DeleteFolder(DeleteFolderRequest request)

Delete folder

### **DeleteFolderRequest** Parameters
```csharp
DeleteFolderRequest(
    string path, 
    string storageName = null, 
    bool? recursive = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **path** | **string**| Folder path e.g. &#39;/folder&#39; | 
 **storageName** | **string**| Storage name | [optional] 
 **recursive** | **bool?**| Enable to delete folders, subfolders and files | [optional] [default to false]

### Return type

void (empty response body)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="deskewimage"></a>
## **DeskewImage**
> System.IO.Stream DeskewImage(DeskewImageRequest request)

Deskew an existing image.

### **DeskewImageRequest** Parameters
```csharp
DeskewImageRequest(
    string name, 
    bool? resizeProportionally, 
    string bkColor = null, 
    string folder = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Image file name. | 
 **resizeProportionally** | **bool?**| Resize proportionally | 
 **bkColor** | **string**| Background color | [optional] 
 **folder** | **string**| Folder | [optional] 
 **storage** | **string**| Storage | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="downloadfile"></a>
## **DownloadFile**
> System.IO.Stream DownloadFile(DownloadFileRequest request)

Download file

### **DownloadFileRequest** Parameters
```csharp
DownloadFileRequest(
    string path, 
    string storageName = null, 
    string versionId = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **path** | **string**| File path e.g. &#39;/folder/file.ext&#39; | 
 **storageName** | **string**| Storage name | [optional] 
 **versionId** | **string**| File version ID to download | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="extractimageproperties"></a>
## **ExtractImageProperties**
> [ImagingResponse](ImagingResponse.md) ExtractImageProperties(ExtractImagePropertiesRequest request)

Get properties of an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.

### **ExtractImagePropertiesRequest** Parameters
```csharp
ExtractImagePropertiesRequest(
    System.IO.Stream imageData)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageData** | **System.IO.Stream**| Input image | 

### Return type

[**ImagingResponse**](ImagingResponse.md)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="filtereffectimage"></a>
## **FilterEffectImage**
> System.IO.Stream FilterEffectImage(FilterEffectImageRequest request)

Apply filtering effects to an existing image.

### **FilterEffectImageRequest** Parameters
```csharp
FilterEffectImageRequest(
    string name, 
    string filterType, 
    FilterPropertiesBase filterProperties, 
    string format = null, 
    string folder = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Filename of an image. | 
 **filterType** | **string**| Filter type (BigRectangular, SmallRectangular, Median, GaussWiener, MotionWiener, GaussianBlur, Sharpen, BilateralSmoothing). | 
 **filterProperties** | [**FilterPropertiesBase**](FilterPropertiesBase.md)| Filter properties. | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | [optional] 
 **folder** | **string**| Folder with image to process. | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="getdiscusage"></a>
## **GetDiscUsage**
> [DiscUsage](DiscUsage.md) GetDiscUsage(GetDiscUsageRequest request)

Get disc usage

### **GetDiscUsageRequest** Parameters
```csharp
GetDiscUsageRequest(
    string storageName = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **storageName** | **string**| Storage name | [optional] 

### Return type

[**DiscUsage**](DiscUsage.md)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="getfileversions"></a>
## **GetFileVersions**
> [FileVersions](FileVersions.md) GetFileVersions(GetFileVersionsRequest request)

Get file versions

### **GetFileVersionsRequest** Parameters
```csharp
GetFileVersionsRequest(
    string path, 
    string storageName = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **path** | **string**| File path e.g. &#39;/file.ext&#39; | 
 **storageName** | **string**| Storage name | [optional] 

### Return type

[**FileVersions**](FileVersions.md)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="getfileslist"></a>
## **GetFilesList**
> [FilesList](FilesList.md) GetFilesList(GetFilesListRequest request)

Get all files and folders within a folder

### **GetFilesListRequest** Parameters
```csharp
GetFilesListRequest(
    string path, 
    string storageName = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **path** | **string**| Folder path e.g. &#39;/folder&#39; | 
 **storageName** | **string**| Storage name | [optional] 

### Return type

[**FilesList**](FilesList.md)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="getimageproperties"></a>
## **GetImageProperties**
> [ImagingResponse](ImagingResponse.md) GetImageProperties(GetImagePropertiesRequest request)

Get properties of an image.

### **GetImagePropertiesRequest** Parameters
```csharp
GetImagePropertiesRequest(
    string name, 
    string folder = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Filename of an image. | 
 **folder** | **string**| Folder with image to process. | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

[**ImagingResponse**](ImagingResponse.md)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="grayscaleimage"></a>
## **GrayscaleImage**
> System.IO.Stream GrayscaleImage(GrayscaleImageRequest request)

Grayscale an existing image.

### **GrayscaleImageRequest** Parameters
```csharp
GrayscaleImageRequest(
    string name, 
    string folder = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Image file name. | 
 **folder** | **string**| Folder | [optional] 
 **storage** | **string**| Storage | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="modifypsd"></a>
## **ModifyPsd**
> System.IO.Stream ModifyPsd(ModifyPsdRequest request)

Update parameters of existing PSD image.

### **ModifyPsdRequest** Parameters
```csharp
ModifyPsdRequest(
    string name, 
    int? channelsCount = null, 
    string compressionMethod = null, 
    bool? fromScratch = null, 
    string folder = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Filename of image. | 
 **channelsCount** | **int?**| Count of color channels. | [optional] [default to 4]
 **compressionMethod** | **string**| Compression method (for now, raw and RLE are supported). | [optional] [default to rle]
 **fromScratch** | **bool?**| Specifies where additional parameters we do not support should be taken from. If this is true – they will be taken from default values for standard image, if it is false – they will be saved from current image. Default is false. | [optional] [default to false]
 **folder** | **string**| Folder with image to process. | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="movefile"></a>
## **MoveFile**
> void MoveFile(MoveFileRequest request)

Move file

### **MoveFileRequest** Parameters
```csharp
MoveFileRequest(
    string srcPath, 
    string destPath, 
    string srcStorageName = null, 
    string destStorageName = null, 
    string versionId = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **srcPath** | **string**| Source file path e.g. &#39;/src.ext&#39; | 
 **destPath** | **string**| Destination file path e.g. &#39;/dest.ext&#39; | 
 **srcStorageName** | **string**| Source storage name | [optional] 
 **destStorageName** | **string**| Destination storage name | [optional] 
 **versionId** | **string**| File version ID to move | [optional] 

### Return type

void (empty response body)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="movefolder"></a>
## **MoveFolder**
> void MoveFolder(MoveFolderRequest request)

Move folder

### **MoveFolderRequest** Parameters
```csharp
MoveFolderRequest(
    string srcPath, 
    string destPath, 
    string srcStorageName = null, 
    string destStorageName = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **srcPath** | **string**| Folder path to move e.g. &#39;/folder&#39; | 
 **destPath** | **string**| Destination folder path to move to e.g &#39;/dst&#39; | 
 **srcStorageName** | **string**| Source storage name | [optional] 
 **destStorageName** | **string**| Destination storage name | [optional] 

### Return type

void (empty response body)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="objectexists"></a>
## **ObjectExists**
> [ObjectExist](ObjectExist.md) ObjectExists(ObjectExistsRequest request)

Check if file or folder exists

### **ObjectExistsRequest** Parameters
```csharp
ObjectExistsRequest(
    string path, 
    string storageName = null, 
    string versionId = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **path** | **string**| File or folder path e.g. &#39;/file.ext&#39; or &#39;/folder&#39; | 
 **storageName** | **string**| Storage name | [optional] 
 **versionId** | **string**| File version ID | [optional] 

### Return type

[**ObjectExist**](ObjectExist.md)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="resizeimage"></a>
## **ResizeImage**
> System.IO.Stream ResizeImage(ResizeImageRequest request)

Resize an existing image.

### **ResizeImageRequest** Parameters
```csharp
ResizeImageRequest(
    string name, 
    int? newWidth, 
    int? newHeight, 
    string format = null, 
    string folder = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Filename of an image. | 
 **newWidth** | **int?**| New width. | 
 **newHeight** | **int?**| New height. | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | [optional] 
 **folder** | **string**| Folder with image to process. | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="rotateflipimage"></a>
## **RotateFlipImage**
> System.IO.Stream RotateFlipImage(RotateFlipImageRequest request)

Rotate and/or flip an existing image.

### **RotateFlipImageRequest** Parameters
```csharp
RotateFlipImageRequest(
    string name, 
    string method, 
    string format = null, 
    string folder = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Filename of an image. | 
 **method** | **string**| RotateFlip method (Rotate180FlipNone, Rotate180FlipX, Rotate180FlipXY, Rotate180FlipY, Rotate270FlipNone, Rotate270FlipX, Rotate270FlipXY, Rotate270FlipY, Rotate90FlipNone, Rotate90FlipX, Rotate90FlipXY, Rotate90FlipY, RotateNoneFlipNone, RotateNoneFlipX, RotateNoneFlipXY, RotateNoneFlipY). | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | [optional] 
 **folder** | **string**| Folder with image to process. | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="saveimageas"></a>
## **SaveImageAs**
> System.IO.Stream SaveImageAs(SaveImageAsRequest request)

Export existing image to another format.

### **SaveImageAsRequest** Parameters
```csharp
SaveImageAsRequest(
    string name, 
    string format, 
    string folder = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Filename of image. | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | 
 **folder** | **string**| Folder with image to process. | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="storageexists"></a>
## **StorageExists**
> [StorageExist](StorageExist.md) StorageExists(StorageExistsRequest request)

Check if storage exists

### **StorageExistsRequest** Parameters
```csharp
StorageExistsRequest(
    string storageName)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **storageName** | **string**| Storage name | 

### Return type

[**StorageExist**](StorageExist.md)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="updateimage"></a>
## **UpdateImage**
> System.IO.Stream UpdateImage(UpdateImageRequest request)

Perform scaling, cropping and flipping of an existing image in a single request.

### **UpdateImageRequest** Parameters
```csharp
UpdateImageRequest(
    string name, 
    int? newWidth, 
    int? newHeight, 
    int? x, 
    int? y, 
    int? rectWidth, 
    int? rectHeight, 
    string rotateFlipMethod, 
    string format = null, 
    string folder = null, 
    string storage = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| Filename of an image. | 
 **newWidth** | **int?**| New width of the scaled image. | 
 **newHeight** | **int?**| New height of the scaled image. | 
 **x** | **int?**| X position of start point for cropping rectangle. | 
 **y** | **int?**| Y position of start point for cropping rectangle. | 
 **rectWidth** | **int?**| Width of cropping rectangle. | 
 **rectHeight** | **int?**| Height of cropping rectangle. | 
 **rotateFlipMethod** | **string**| RotateFlip method (Rotate180FlipNone, Rotate180FlipX, Rotate180FlipXY, Rotate180FlipY, Rotate270FlipNone, Rotate270FlipX, Rotate270FlipXY, Rotate270FlipY, Rotate90FlipNone, Rotate90FlipX, Rotate90FlipXY, Rotate90FlipY, RotateNoneFlipNone, RotateNoneFlipX, RotateNoneFlipXY, RotateNoneFlipY). Default is RotateNoneFlipNone. | 
 **format** | **string**| Resulting image format. Please, refer to https://docs.aspose.cloud/display/psd/Supported+File+Formats#SupportedFileFormats-CommonOperationsFormatSupportMap for possible use-cases. | [optional] 
 **folder** | **string**| Folder with image to process. | [optional] 
 **storage** | **string**| Your Aspose Cloud Storage name. | [optional] 

### Return type

**System.IO.Stream**

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

<a name="uploadfile"></a>
## **UploadFile**
> [FilesUploadResult](FilesUploadResult.md) UploadFile(UploadFileRequest request)

Upload file

### **UploadFileRequest** Parameters
```csharp
UploadFileRequest(
    string path, 
    System.IO.Stream file, 
    string storageName = null)
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **path** | **string**| Path where to upload including filename and extension e.g. /file.ext or /Folder 1/file.ext             If the content is multipart and path does not contains the file name it tries to get them from filename parameter             from Content-Disposition header.              | 
 **file** | **System.IO.Stream**| File to upload | 
 **storageName** | **string**| Storage name | [optional] 

### Return type

[**FilesUploadResult**](FilesUploadResult.md)

[[Back to top]](#) [[Back to API list]](API_README.md#documentation-for-api-endpoints) [[Back to Model list]](API_README.md#documentation-for-models) [[Back to API_README]](API_README.md)

