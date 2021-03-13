# FaceRecognitionDotNet.Client.Api.FaceRegistrationApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**FaceRegistrationGetAllGet**](FaceRegistrationApi.md#faceregistrationgetallget) | **GET** /FaceRegistration/GetAll | Get all registered person data.
[**FaceRegistrationRegisterPost**](FaceRegistrationApi.md#faceregistrationregisterpost) | **POST** /FaceRegistration/Register | Register person data.


<a name="faceregistrationgetallget"></a>
# **FaceRegistrationGetAllGet**
> List&lt;Registration&gt; FaceRegistrationGetAllGet ()

Get all registered person data.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FaceRecognitionDotNet.Client.Api;
using FaceRecognitionDotNet.Client.Client;
using FaceRecognitionDotNet.Client.Model;

namespace Example
{
    public class FaceRegistrationGetAllGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new FaceRegistrationApi(config);

            try
            {
                // Get all registered person data.
                List<Registration> result = apiInstance.FaceRegistrationGetAllGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FaceRegistrationApi.FaceRegistrationGetAllGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List&lt;Registration&gt;**](Registration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |
| **500** | Server Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="faceregistrationregisterpost"></a>
# **FaceRegistrationRegisterPost**
> void FaceRegistrationRegisterPost (Registration registration = null)

Register person data.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FaceRecognitionDotNet.Client.Api;
using FaceRecognitionDotNet.Client.Client;
using FaceRecognitionDotNet.Client.Model;

namespace Example
{
    public class FaceRegistrationRegisterPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new FaceRegistrationApi(config);
            var registration = new Registration(); // Registration |  (optional) 

            try
            {
                // Register person data.
                apiInstance.FaceRegistrationRegisterPost(registration);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling FaceRegistrationApi.FaceRegistrationRegisterPost: " + e.Message );
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
 **registration** | [**Registration**](Registration.md)|  | [optional] 

### Return type

void (empty response body)

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
| **500** | Server Error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

