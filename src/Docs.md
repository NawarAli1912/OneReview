# URI:
- Nonus.
- Plural.
- Nest resources* not more than 2 to 3 levels.
    GET /products/{product-id}/reviews/{review-id}
- Consistency
    Casing camleCase
- Versioning

# Http Methods:
## GET: /products 
fetching a resource(s).
- request: header caching details, with no body
- response: caching details
- when the client sends a request with caching details the server must check if there is a newer version if not we can return 304 Not Modified, 200 Ok with the latest version if there is a newer version

## POST: /products
creating a resource
for a single resource we are initiating some action processing on that resource
response:201 created, 202 Accepted

## PUT: 
on a collection is not something that you would do
on a single resource if the resource doesn't exist yet then create that otherwise update
response 201 Created, 200 Ok and on the body the resource that was created, 204 No Content
Header: Location

## Delete: 
on a collection dont
single delete the resource 
status code 204 No content
no bodyf

