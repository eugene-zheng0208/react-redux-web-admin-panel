import React from 'react';
import { ruleRunner } from '../ruleRunner';
import { required, minLength, maxLength } from './rules';

export const fieldValidationsRules = [
    ruleRunner("name", "Name", required, minLength(3), maxLength(20)),
    ruleRunner("modelName", "Model Name", required, minLength(3), maxLength(20)),
    ruleRunner("color", "Color", required, minLength(3), maxLength(15)),
    ruleRunner("listPrice", "Price", required),
    ruleRunner("size", "Size", required, maxLength(3)),
    ruleRunner("weight", "Weight", required),
    ruleRunner("description", "Description", required, minLength(10), maxLength(150)),
    ruleRunner("subcategoryName", "Subcategory", required),
    ruleRunner("largePhoto", "Photo", required)
  ];
