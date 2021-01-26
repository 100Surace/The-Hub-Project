import React, { useState, useEffect } from 'react';
import { Grid, TextField, withStyles, Button, FormControl, InputLabel, Select, MenuItem, TextareaAutosize, Switch } from '@material-ui/core';
import useForm from '../useForm';
import { connect } from 'react-redux';
import * as actions from '../../actions/organization/module';
import { useToasts } from 'react-toast-notifications';
import API from '../../actions/api';

const mapStateToProps = (state) => ({
  moduleList: state.modules.list,
});

const mapActionToProps = {
  create: actions.create,
  update: actions.update,
};

const styles = (theme) => ({
  root: {
    '& .MuiTextField-root': {
      margin: theme.spacing(1),
      minWidth: 230,
    },
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 230,
  },
  smMargin: {
    margin: theme.spacing(1),
  },
  container: {
    padding: '8px',
  },
});

const initialFieldValues = {
  id: '',
  moduleCategoryId: '',
  serviceType: '',
  organizationType: '',
  orgName: '',
  secondEmail: '',
  secondPhone: '',
  shortDesc: '',
  longDesc: '',
  status: '',
  orgCreatedDate: '',
};

const ModuleForm = ({ classes, ...props }) => {
  //toast msg.
  const { addToast } = useToasts();
  // states
  const [logo, setLogo] = useState();
  const [bannerImg, setBanner] = useState();
  const [orgImg, setOrgImg] = useState();
  const [moduleCategories, setModuleCategories] = useState([]);

  const validate = (fieldValues = values) => {
    let temp = { ...errors };
    if ('moduleName' in fieldValues) temp.moduleName = fieldValues.moduleName ? '' : 'This field is required.';

    setErrors({
      ...temp,
    });

    if (fieldValues === values) {
      return Object.values(temp).every((x) => x === '');
    }
  };

  const { values, setValues, errors, setErrors, handleInputChange, resetForm } = useForm(initialFieldValues, validate, props.setCurrentId);

  const handleSubmit = (e) => {
    e.preventDefault();

    const formData = new FormData();
    if (logo) formData.append('logo', logo);
    if (bannerImg) formData.append('bannerImg', bannerImg);
    if (orgImg) formData.append('orgImg', orgImg);

    if (validate()) {
      const onSuccess = () => {
        resetForm();
        addToast('Submitted successfully', { appearance: 'success' });
      };

      if (props.currentId === 0 || props.currentId === undefined) props.create(formData, onSuccess);
      else props.update(props.currentId, formData, onSuccess);
    }
  };

  const handleLogoUpload = (e) => {
    const logo = e.target.files[0];
    setLogo({ logo });
  };

  const handleBannerUpload = (e) => {
    const bannerImg = e.target.files[0];
    setBanner({ bannerImg });
  };

  const handleOrgImgUpload = (e) => {
    const OrgImg = e.target.files[0];
    setOrgImg({ OrgImg });
  };

  useEffect(() => {
    fetchModuleCategories().then(({ data }) => setModuleCategories(data));
    if (props.currentId !== 0) {
      setValues({
        ...props.moduleList.find((x) => x.ids === props.currentId),
      });
      setErrors({});
    }
  });

  const fetchModuleCategories = () => {
    return API.moduleCategories().fetchAll();
  };

  return (
    <form autoComplete='off' noValidate className={classes.root} onSubmit={handleSubmit}>
      <Grid container>
        <Grid item xs={12}>
          <TextField
            name='id'
            variant='outlined'
            label='Hub User Id'
            value={values.id}
            onChange={handleInputChange}
            {...(errors.id && { error: true, helperText: errors.id })}
          />
          <FormControl variant='outlined' className={classes.formControl}>
            <InputLabel>Module Category</InputLabel>
            <Select
              name='moduleCategoryId'
              value={values.moduleCategoryId}
              onChange={handleInputChange}
              label='Module Category'
              {...(errors.moduleCategoryId && { error: true, helperText: errors.moduleCategoryId })}>
              {moduleCategories.map(({ ids, moduleCategoryName }) => {
                return (
                  <MenuItem key={ids} value={ids}>
                    {moduleCategoryName}
                  </MenuItem>
                );
              })}
            </Select>
          </FormControl>
          <FormControl variant='outlined' className={classes.formControl}>
            <InputLabel>Service Type</InputLabel>
            <Select
              name='serviceType'
              value={values.serviceType}
              onChange={handleInputChange}
              label='Service Type'
              {...(errors.serviceType && { error: true, helperText: errors.serviceType })}>
              <MenuItem value={1}>Private</MenuItem>
              <MenuItem value={2}>Public</MenuItem>
            </Select>
          </FormControl>
          <FormControl variant='outlined' className={classes.formControl}>
            <InputLabel>Organization Type</InputLabel>
            <Select
              name='organizationType'
              value={values.organizationType}
              onChange={handleInputChange}
              label='Organization Type'
              {...(errors.organizationType && { error: true, helperText: errors.organizationType })}>
              <MenuItem value={1}>National</MenuItem>
              <MenuItem value={2}>International</MenuItem>
              <MenuItem value={3}>Multinational</MenuItem>
            </Select>
          </FormControl>
          <TextField
            name='orgName'
            variant='outlined'
            label='Organization Name'
            value={values.orgName}
            onChange={handleInputChange}
            {...(errors.orgName && { error: true, helperText: errors.orgName })}
          />
          <TextField
            name='secondEmail'
            variant='outlined'
            label='second Email'
            value={values.secondEmail}
            onChange={handleInputChange}
            {...(errors.secondEmail && { error: true, helperText: errors.secondEmail })}
          />
          <TextField
            name='secondPhone'
            variant='outlined'
            label='second Phone'
            value={values.secondPhone}
            onChange={handleInputChange}
            {...(errors.secondPhone && { error: true, helperText: errors.secondPhone })}
          />
          <div className={classes.container}>
            <TextareaAutosize
              name='shortDesc'
              variant='outlined'
              label='Short Desc'
              value={values.shortDesc}
              onChange={handleInputChange}
              aria-label='minimum height'
              rowsMin={3}
              placeholder='Short Description'
              {...(errors.shortDesc && { error: true, helperText: errors.shortDesc })}
            />
          </div>
          <div className={classes.container}>
            <TextareaAutosize
              name='longDesc'
              variant='outlined'
              label='long Desc'
              value={values.longDesc}
              onChange={handleInputChange}
              aria-label='minimum height'
              rowsMin={3}
              placeholder='Detailed Description'
            />
          </div>
          <FormControl>
            <label>Logo</label>
            <div className={classes.container}>
              <input
                type='file'
                name='logo'
                accept='image/*'
                label='logo'
                onChange={handleLogoUpload}
                {...(errors.logo && { error: true, helperText: errors.logo })}
              />
            </div>
          </FormControl>
          <FormControl>
            <label>Banner</label>
            <div className={classes.container}>
              <input
                type='file'
                name='bannerImg'
                accept='image/*'
                label='bannerImg'
                onChange={handleBannerUpload}
                {...(errors.bannerImg && { error: true, helperText: errors.bannerImg })}
              />
            </div>
          </FormControl>
          <FormControl>
            <label>Images</label>
            <div className={classes.container}>
              <input
                type='file'
                name='orgImg'
                accept='image/*'
                label='orgImg'
                onChange={handleOrgImgUpload}
                {...(errors.orgImg && { error: true, helperText: errors.orgImg })}
              />
            </div>
          </FormControl>
          <FormControl variant='outlined' className={classes.formControl}>
            <label>Status</label>
            <Switch name='status' checked={values.status} onChange={handleInputChange} color='primary' />
          </FormControl>
        </Grid>

        <Grid item xs={12}>
          <div>
            <Button variant='contained' color='primary' type='submit' className={classes.smMargin}>
              Submit
            </Button>
            <Button variant='contained' className={classes.smMargin} onClick={resetForm}>
              Reset
            </Button>
          </div>
        </Grid>
      </Grid>
    </form>
  );
};

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(ModuleForm));
