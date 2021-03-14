# FaceRecognitionDotNet.Client.Api.FaceEncodingApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**FaceEncodingEncodingPost**](FaceEncodingApi.md#faceencodingencodingpost) | **POST** /FaceEncoding/Encoding | Returns an face feature data from image contains a human face.


<a name="faceencodingencodingpost"></a>
# **FaceEncodingEncodingPost**
> Encoding FaceEncodingEncodingPost (Image image = null)

Returns an face feature data from image contains a human face.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FaceRecognitionDotNet.Client.Api;
using FaceRecognitionDotNet.Client.Client;
using FaceRecognitionDotNet.Client.Model;

namespace Example
{
    public class FaceEncodingEncodingPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new FaceEncodingApi(config);
            var image = new Image(); // Image |  (optional) 

            try
            {
                // Returns an face feature data from image contains a human face.
                Encoding result = apiInstance.FaceEncodingEncodingPost(image);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FaceEncodingApi.FaceEncodingEncodingPost: " + e.Message );
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

[**Encoding**](Encoding.md)

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

