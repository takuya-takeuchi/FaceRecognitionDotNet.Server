# FaceRecognitionDotNet.Client.Api.FaceDetectionApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**FaceDetectionLocationsPost**](FaceDetectionApi.md#facedetectionlocationspost) | **POST** /FaceDetection/Locations | Returns an enumerable collection of face location correspond to all faces in specified image.


<a name="facedetectionlocationspost"></a>
# **FaceDetectionLocationsPost**
> List&lt;FaceArea&gt; FaceDetectionLocationsPost (Image image = null)

Returns an enumerable collection of face location correspond to all faces in specified image.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FaceRecognitionDotNet.Client.Api;
using FaceRecognitionDotNet.Client.Client;
using FaceRecognitionDotNet.Client.Model;

namespace Example
{
    public class FaceDetectionLocationsPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new FaceDetectionApi(config);
            var image = new Image(); // Image |  (optional) 

            try
            {
                // Returns an enumerable collection of face location correspond to all faces in specified image.
                List<FaceArea> result = apiInstance.FaceDetectionLocationsPost(image);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FaceDetectionApi.FaceDetectionLocationsPost: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **image** | [**Image**](Image.md)|  | [optional] 

### Return type

[**List&lt;FaceArea&gt;**](FaceArea.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **400** | Bad Request |  -  |
| **429** | Client Error |  -  |
| **500** | Server Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

