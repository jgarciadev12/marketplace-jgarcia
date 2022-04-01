import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {OfferItemComponent} from './offer-item/offer-item.component';
import {OfferCreationComponent} from './offer-creation/offer-creation.component';
import {OfferListComponent} from './offer-list/offer-list.component';
import {ReactiveFormsModule} from '@angular/forms';
import { PaginationComponent } from './pagination/pagination.component';
import { CoreModule } from '../core/core.module';

@NgModule({
  declarations: [OfferItemComponent, OfferCreationComponent, OfferListComponent, PaginationComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CoreModule
  ]
})
export class OffersModule { }
