<a name="documentation-for-api-endpoints"></a>
## Documentation for API endpoints

All URIs are relative to *https://api.aspose.cloud/v3.0*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*PsdApi* | [**CopyFile**](PsdApi.md#copyfile) | **PUT** /psd/storage/file/copy/{srcPath} | Copy file
*PsdApi* | [**CopyFolder**](PsdApi.md#copyfolder) | **PUT** /psd/storage/folder/copy/{srcPath} | Copy folder
*PsdApi* | [**CreateCroppedImage**](PsdApi.md#createcroppedimage) | **POST** /psd/crop | Crop an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
*PsdApi* | [**CreateDeskewedImage**](PsdApi.md#createdeskewedimage) | **POST** /psd/deskew | Deskew an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
*PsdApi* | [**CreateFolder**](PsdApi.md#createfolder) | **PUT** /psd/storage/folder/{path} | Create the folder
*PsdApi* | [**CreateGrayscaledImage**](PsdApi.md#creategrayscaledimage) | **POST** /psd/grayscale | Grayscales an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
*PsdApi* | [**CreateModifiedPsd**](PsdApi.md#createmodifiedpsd) | **POST** /psd/psd | Update parameters of PSD image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
*PsdApi* | [**CreateResizedImage**](PsdApi.md#createresizedimage) | **POST** /psd/resize | Resize an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
*PsdApi* | [**CreateRotateFlippedImage**](PsdApi.md#createrotateflippedimage) | **POST** /psd/rotateflip | Rotate and/or flip an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
*PsdApi* | [**CreateSavedImageAs**](PsdApi.md#createsavedimageas) | **POST** /psd/saveAs | Export existing image to another format. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.             
*PsdApi* | [**CreateUpdatedImage**](PsdApi.md#createupdatedimage) | **POST** /psd/updateImage | Perform scaling, cropping and flipping of an image in a single request. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
*PsdApi* | [**CropImage**](PsdApi.md#cropimage) | **GET** /psd/{name}/crop | Crop an existing image.
*PsdApi* | [**DeleteFile**](PsdApi.md#deletefile) | **DELETE** /psd/storage/file/{path} | Delete file
*PsdApi* | [**DeleteFolder**](PsdApi.md#deletefolder) | **DELETE** /psd/storage/folder/{path} | Delete folder
*PsdApi* | [**DeskewImage**](PsdApi.md#deskewimage) | **GET** /psd/{name}/deskew | Deskew an existing image.
*PsdApi* | [**DownloadFile**](PsdApi.md#downloadfile) | **GET** /psd/storage/file/{path} | Download file
*PsdApi* | [**ExtractImageProperties**](PsdApi.md#extractimageproperties) | **POST** /psd/properties | Get properties of an image. Image data is passed as zero-indexed multipart/form-data content or as raw body stream.
*PsdApi* | [**FilterEffectImage**](PsdApi.md#filtereffectimage) | **PUT** /psd/{name}/filterEffect | Apply filtering effects to an existing image.
*PsdApi* | [**GetDiscUsage**](PsdApi.md#getdiscusage) | **GET** /psd/storage/disc | Get disc usage
*PsdApi* | [**GetFileVersions**](PsdApi.md#getfileversions) | **GET** /psd/storage/version/{path} | Get file versions
*PsdApi* | [**GetFilesList**](PsdApi.md#getfileslist) | **GET** /psd/storage/folder/{path} | Get all files and folders within a folder
*PsdApi* | [**GetImageProperties**](PsdApi.md#getimageproperties) | **GET** /psd/{name}/properties | Get properties of an image.
*PsdApi* | [**GrayscaleImage**](PsdApi.md#grayscaleimage) | **GET** /psd/{name}/grayscale | Grayscale an existing image.
*PsdApi* | [**ModifyPsd**](PsdApi.md#modifypsd) | **GET** /psd/{name}/psd | Update parameters of existing PSD image.
*PsdApi* | [**MoveFile**](PsdApi.md#movefile) | **PUT** /psd/storage/file/move/{srcPath} | Move file
*PsdApi* | [**MoveFolder**](PsdApi.md#movefolder) | **PUT** /psd/storage/folder/move/{srcPath} | Move folder
*PsdApi* | [**ObjectExists**](PsdApi.md#objectexists) | **GET** /psd/storage/exist/{path} | Check if file or folder exists
*PsdApi* | [**ResizeImage**](PsdApi.md#resizeimage) | **GET** /psd/{name}/resize | Resize an existing image.
*PsdApi* | [**RotateFlipImage**](PsdApi.md#rotateflipimage) | **GET** /psd/{name}/rotateflip | Rotate and/or flip an existing image.
*PsdApi* | [**SaveImageAs**](PsdApi.md#saveimageas) | **GET** /psd/{name}/saveAs | Export existing image to another format.
*PsdApi* | [**StorageExists**](PsdApi.md#storageexists) | **GET** /psd/storage/{storageName}/exist | Check if storage exists
*PsdApi* | [**UpdateImage**](PsdApi.md#updateimage) | **GET** /psd/{name}/updateImage | Perform scaling, cropping and flipping of an existing image in a single request.
*PsdApi* | [**UploadFile**](PsdApi.md#uploadfile) | **PUT** /psd/storage/file/{path} | Upload file


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.DiscUsage](DiscUsage.md)
 - [Model.Error](Error.md)
 - [Model.ErrorDetails](ErrorDetails.md)
 - [Model.FileVersions](FileVersions.md)
 - [Model.FilesList](FilesList.md)
 - [Model.FilesUploadResult](FilesUploadResult.md)
 - [Model.FilterPropertiesBase](FilterPropertiesBase.md)
 - [Model.ImagingResponse](ImagingResponse.md)
 - [Model.ObjectExist](ObjectExist.md)
 - [Model.PsdProperties](PsdProperties.md)
 - [Model.StorageExist](StorageExist.md)
 - [Model.StorageFile](StorageFile.md)
 - [Model.BigRectangularFilterProperties](BigRectangularFilterProperties.md)
 - [Model.BilateralSmoothingFilterProperties](BilateralSmoothingFilterProperties.md)
 - [Model.ConvolutionFilterProperties](ConvolutionFilterProperties.md)
 - [Model.DeconvolutionFilterProperties](DeconvolutionFilterProperties.md)
 - [Model.FileVersion](FileVersion.md)
 - [Model.MedianFilterProperties](MedianFilterProperties.md)
 - [Model.SmallRectangularFilterProperties](SmallRectangularFilterProperties.md)
 - [Model.GaussWienerFilterProperties](GaussWienerFilterProperties.md)
 - [Model.GaussianBlurFilterProperties](GaussianBlurFilterProperties.md)
 - [Model.MotionWienerFilterProperties](MotionWienerFilterProperties.md)
 - [Model.SharpenFilterProperties](SharpenFilterProperties.md)

