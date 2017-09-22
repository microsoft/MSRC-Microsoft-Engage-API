#import <Foundation/Foundation.h>

int main(int argc, const char * argv[])
{
    NSAutoreleasePool * pool = [[NSAutoreleasePool alloc] init];
    
    NSString* path = @"https://api.msrc.microsoft.com/engage/cars";
    NSArray* array = @[
                         // Request parameters
                         @"entities=true",
                      ];
    
    NSString* string = [array componentsJoinedByString:@"&"];
    path = [path stringByAppendingFormat:@"?%@", string];

    NSLog(@"%@", path);

    NSMutableURLRequest* _request = [NSMutableURLRequest requestWithURL:[NSURL URLWithString:path]];
    [_request setHTTPMethod:@"POST"];
    // Request headers
    [_request setValue:@"application/json" forHTTPHeaderField:@"Content-Type"];
    [_request setValue:@"{subscription key}" forHTTPHeaderField:@"api-key"];
    // Request body
    [_request setHTTPBody:[@"{body}" dataUsingEncoding:NSUTF8StringEncoding]];
    
    NSURLResponse *response = nil;
    NSError *error = nil;
    NSData* _connectionData = [NSURLConnection sendSynchronousRequest:_request returningResponse:&response error:&error];

    if (nil != error)
    {
        NSLog(@"Error: %@", error);
    }
    else
    {
        NSError* error = nil;
        NSMutableDictionary* json = nil;
        NSString* dataString = [[NSString alloc] initWithData:_connectionData encoding:NSUTF8StringEncoding];
        NSLog(@"%@", dataString);
        
        if (nil != _connectionData)
        {
            json = [NSJSONSerialization JSONObjectWithData:_connectionData options:NSJSONReadingMutableContainers error:&error];
        }
        
        if (error || !json)
        {
            NSLog(@"Could not parse loaded json with error:%@", error);
        }
        
        NSLog(@"%@", json);
        _connectionData = nil;
    }
    
    [pool drain];

    return 0;
}
