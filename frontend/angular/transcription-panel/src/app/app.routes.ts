import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AudiosComponent } from './audios/audios.component';
import { UploadComponent } from './upload/upload.component';
import { LogComponent } from './log/log.component';
import { UserManagementComponent } from './user-management/user-management.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'audios', component: AudiosComponent },
  { path: 'upload', component: UploadComponent }, 
  { path: 'logs', component: LogComponent },
 { path: 'user-management', component: UserManagementComponent } 

];

