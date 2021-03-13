<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="BCS6thEMFall2020DemoPrject.Setting.Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPageTitle" runat="server">
    DEPARTMENT
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPath" runat="server">
                <li id="test" class="breadcrumb-item"><a href="/Dashboard.aspx">Dashboard</a>
                </li>
                <li class="breadcrumb-item active">Setting
                </li> 
                <li class="breadcrumb-item active">Department
                </li> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentDescription" runat="server">
    You can use this form to add a new department and manipulate (Edit/Delete) the saved data.
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="contentBody" runat="server">
    
<section id="basic-form-layouts">
	<div class="row match-height">
		<div class="col-md-12">
			<div class="card">
				<div class="card-header">
					<h4 class="card-title" id="basic-layout-form">Department Info</h4>
					<a class="heading-elements-toggle"><i class="icon-ellipsis font-medium-3"></i></a>
					<div class="heading-elements">
						<ul class="list-inline mb-0">
							<li><a data-action="collapse"><i class="icon-minus4"></i></a></li>
							<li><a data-action="reload"><i class="icon-reload"></i></a></li>
							<li><a data-action="expand"><i class="icon-expand2"></i></a></li>
							<li><a data-action="close"><i class="icon-cross2"></i></a></li>
						</ul>
					</div>
				</div>
				<div class="card-body collapse in">
					<div class="card-block">
						<div class="card-text">
							<p>Please kindly fill the below <code>form</code> according to valid document and evidence.</p>
						</div>
							<div class="form-body">
								<h4 class="form-section"><i class="icon-file-text"></i> Details</h4>
								<div class="row">
									<div class="col-md-4">
										<div class="form-group">
                                            <input id="hfCode" type="hidden" />
											<label for="txtTitle">Title</label>
                                            <input id="txtTitle" type="text" class="form-control" placeholder="Title" />
										</div>
									</div>
									<div class="col-md-4">
										<div class="form-group">
											<label for="txtAbbreviation">Abbreviation</label>
											<input id="txtAbbreviation" type="text" class="form-control" placeholder="Abbreviation" />
										</div>
									</div>
									<div class="col-md-4">
										<div class="form-group">
											<label for="txtFarsiTitle">Farsi Title</label>
											<input id="txtFarsiTitle" type="text" class="form-control" placeholder="Farsi Title" />
										</div>
									</div>
								</div>
								
							</div>
							<div class="form-actions center">
									<button type="button" class="btn btn-warning mr-1" onclick="ClearForm();">
                                        <i class="icon-cross2"></i>Cancel
	                           
                                    </button>
                                    <button type="button" id="btnSave" class="btn btn-primary">
                                        <i class="icon-check2"></i>Save
	                           
                                    </button>
                                    <button type="button" id="btnUpdate" class="btn btn-info">
                                        <i class="icon-check-circle"></i>Update
	                           
                                    </button>
							</div>
					</div>
				</div>
			</div>
		</div>

	</div>
	<div class="row match-height">
		<div class="col-md-12">
			<div class="card">
				<div class="card-header">
					<h4 class="card-title">Departement Year Data in the System</h4>
					<a class="heading-elements-toggle"><i class="icon-ellipsis font-medium-3"></i></a>
					<div class="heading-elements">
						<ul class="list-inline mb-0">
							<li><a data-action="collapse"><i class="icon-minus4"></i></a></li>
							<li><a data-action="reload"><i class="icon-reload"></i></a></li>
							<li><a data-action="expand"><i class="icon-expand2"></i></a></li>
							<li><a data-action="close"><i class="icon-cross2"></i></a></li>
						</ul>
					</div>
				</div>
				<div class="card-body collapse in">
					<div class="card-block">
						<div class="card-text">
							<p>Please kindly search your <code>required record</code> and you can change or manipute the data.</p>
						</div>
							<div class="form-body">
								<h4 class="form-section"><i class="icon-file-text"></i> Details</h4>
								<div class="row">
									<div class="col-md-12 table-responsive">
                                        <div id="dvData">

                                        </div>
									</div>
								</div>
								
							</div>
					</div>
				</div>
			</div>
		</div>

	</div>
</section>
		
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="scripts" runat="server">
    <script src="../Scripts/Department.js"></script>
</asp:Content>
