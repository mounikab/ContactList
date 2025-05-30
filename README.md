Create a browser-based web application, both frontend and backend for a simple
contact list. Use C# for server implementation.
Upon (server) startup, application should create a data store in memory with at least
50 contacts. You may define what a contact data type should look like. To give a
few examples: may contain name, address, phone number, birthday, workplace.
Data store should be in memory on server side and client should not cache, should
fetch whenever a user loads a new view. Data store should not persist ie. to file or
database, thus data will be discarded when terminating the application, and re-
created at next startup. Choose a data structure to support all of the operations
effectively.
The application should have two screens:
1. List view: displays all contacts in a table
2. Detail view: displays one contact (read-only)
Users should be able to navigate between views.
 Upgrade detail view, so it allows updating a contact and corresponding
server side operation
 Continue to maintain in-memory data store
