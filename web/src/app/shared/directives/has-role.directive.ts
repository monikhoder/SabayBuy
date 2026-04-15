import { Directive, effect, inject, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { AccountService } from '../../core/services/account.service';

@Directive({
  selector: '[appHasRole]',
  standalone: true
})
export class HasRoleDirective {
  private accountService = inject(AccountService);
  private viewContainerRef = inject(ViewContainerRef);
  private templateRef = inject(TemplateRef);

  private allowedRoles: string[] = [];
  private hasView = false;

  @Input() set appHasRole(roles: string[]) {
    this.allowedRoles = roles;
    this.updateView();
  }

  constructor() {
    effect(() => {
      const user = this.accountService.currentUser();
      this.updateView();
    });
  }

  private updateView() {
    const userRole = this.accountService.currentUser()?.role;
    const hasAccess = !!userRole && this.allowedRoles.includes(userRole);

    if (hasAccess && !this.hasView) {
      this.viewContainerRef.createEmbeddedView(this.templateRef);
      this.hasView = true;
    } else if (!hasAccess && this.hasView) {
      this.viewContainerRef.clear();
      this.hasView = false;
    }
  }
}