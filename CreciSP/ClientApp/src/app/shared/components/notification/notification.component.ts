import { AuthService } from 'src/app/shared/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../../services/notification.service';
import { NoticationModel } from '../../models/noticication.model';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {
  notifications: NoticationModel[];
  constructor(
    private notificationService: NotificationService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.getNotifications();
  }

  getNotifications(): void {
    const user = this.authService.getUserLogged();

    if (user?.id) {
      this.notificationService.getNotificationByUserId(user.id)
        .subscribe(value => this.notifications = value);
    }
  }

}
