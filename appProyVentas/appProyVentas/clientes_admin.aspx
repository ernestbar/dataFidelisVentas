<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="clientes_admin.aspx.cs" Inherits="appProyVentas.clientes_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ObjectDataSource ID="odsClientesTodos" runat="server" SelectMethod="PR_SEG_GET_CLIENTES" TypeName="appProyVentas.Clases.Clientes">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoSociedad" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appProyVentas.Clases.Dominios">
        <SelectParameters>
			<asp:Parameter Name="PV_DOMINIO" DefaultValue="TIPO SOCIEDAD" />
        </SelectParameters>
    </asp:ObjectDataSource>


	
	<%--<asp:ObjectDataSource ID="odsContactosCliente" runat="server" SelectMethod="PR_PAR_GET_MEDIOS_CONTACTO_CLIENTE" TypeName="appRRHHadmin.Clases.Medios_contratos">
		<SelectParameters>
            <asp:ControlParameter ControlID="ddlClienteFiltro" Name="PV_ID_CLIENTE" Type="String" />
        </SelectParameters>
		</asp:ObjectDataSource>--%>
	
	<style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .ErrorControl
        {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
	<script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "form-control ErrorControl";
                        } else {
                            control.className = "form-control";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
	<!-- begin #content -->
		<div id="content" class="content">
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblCodCliente" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			 <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
			<asp:Label ID="Label1" Visible="false" ForeColor="Yellow" Font-Size="Larger" runat="server" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn btn-green btn-sm col-6" OnClick="btnNuevo_Click" runat="server" Text="AGREGAR NUEVO" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Administrador Clientes:</h1>
										<%--	<asp:DropDownList ID="ddlDominio" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlDominio_SelectedIndexChanged"  DataSourceID="odsDominiosOnly" DataTextField="dominio" DataValueField="dominio" OnDataBound="ddlDominio_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDominio" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
											<!-- end page-header -->
											<!-- begin panel -->
											<div class="panel panel-inverse">
												<!-- begin panel-heading -->
												<div class="panel-heading">
													<div class="panel-heading-btn">
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
													</div>
													<h4 class="panel-title">Registros</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
												<table id="data-table-buttons" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">CODIGO SISTEMA</th>
															<th class="text-nowrap">RAZON SOCIAL</th>
															<th class="text-nowrap">TELEFONO</th>
															<th class="text-nowrap">NIT</th>
															<th class="text-nowrap">TIPO SOCIEDAD</th>
															<th class="text-nowrap">ESTADO</th>
															
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsClientesTodos" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
															<td><asp:Label ID="lblEsPrincipa1l" runat="server" Text='<%# Eval("CLI_ID_CLIENTE") %>'></asp:Label></td>
															<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("CLI_RAZON_SOCIAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("CLI_TELEFONO") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto0" runat="server" Text='<%# Eval("CLI_NIT") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto1" runat="server" Text='<%# Eval("DESC_TIPO_SOCIEDAD") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto7" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															
															<td>
																<asp:Button ID="btnEditar"  class="btn btn-success btn-sm"  CommandArgument='<%# Eval("CLI_ID_CLIENTE") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CLI_ID_CLIENTE") +"|"+Eval("CLI_ESTADO") %>' OnClick="btnEliminar_Click" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" runat="server" Text="Activa/Desactivar" ToolTip="Borrar registro" />
															</td>
															
															
														</tr>
														</ItemTemplate>
														</asp:Repeater>
														
													
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
										</div>
        </asp:View>
		 <asp:View ID="View2" runat="server">
			<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-md-6 offset-md-2">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Cliente</legend>
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo Sociedad:</label>
						<div class="col-md-6">
                             			<asp:DropDownList ID="ddlTipoSociedad" class="form-control"   DataSourceID="odsTipoSociedad" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlTipoSociedad_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoSociedad" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					
						<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Razon Social:</label>
							<div class="col-md-6">
								<asp:TextBox ID="txtRazonSocial" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtRazonSocial" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						</div>
						<!-- end form-group row -->
					
							<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">NIT:</label>
							<div class="col-md-6">
								<asp:TextBox ID="txtNIT" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtNIT" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
                        
						</div>
						<!-- end form-group row -->
						<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Telefono:</label>
							<div class="col-md-6">
								<asp:TextBox ID="txtTelefono" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtTelefono" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
                        
						</div>
						<!-- end form-group row -->
						
								
					
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-info" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-default"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
		
    </asp:MultiView>
			
		</div>
		<!-- end #content -->	
</asp:Content>
