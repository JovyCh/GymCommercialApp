import { instructorApi } from './instructorApi';
import { membersApi } from './membersApi';
import { adminApi } from './adminApi';
import { userApi } from './userApi';

const agent = {
  Admin: adminApi,
  Members: membersApi,
  Instructor: instructorApi,
  User: userApi,
};

export default agent;