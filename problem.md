Training Management System 

https://www.tutorialsteacher.com/mvc/htmlhelper-dropdownlist-dropdownlistfor


User 
Create Users 
where they can be managers, employees, admin
Only admin can add users with 2 roles manager, employee
While adding user, 2 roles shud be visible in drop down
While adding users, manager names shud be displayed in drop down
Display all users alongwith their manager names

Once registered, users shud be able to login

There will be 5 courses, DotNet, Java, DotNetFullStack, Cloud, MERN
CourseId, CourseName, Description, Duration (in days)
Batch : Courses will be conducted in Batches
BatchId, BatchName(Like B001, B002...), Trainer, StartDate, Course that will be conducted

After login,  Admins can see all users , batches, courses
Only Admin can add, delete (soft delete) ,edit users & courses, batches
Different courses will be conducted in different batches
While adding users, admin can assign them some role (Use enum for this)
Admin - 0 , Manager - 1, Employee -2 (Admins cant be added from FE)
After login, 
Employees can see all courses & batch details, They can send request for some batch

After login, Managers can accept or reject their requests

Employees shud be able to see their request status
