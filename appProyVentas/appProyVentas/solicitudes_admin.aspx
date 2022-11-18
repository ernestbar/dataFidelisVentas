<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="solicitudes_admin.aspx.cs" Inherits="appProyVentas.solicitudes_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ObjectDataSource ID="odsClientesTodos" runat="server" SelectMethod="PR_SEG_GET_CLIENTES" TypeName="appProyVentas.Clases.Clientes">
		</asp:ObjectDataSource>
	<%--<asp:ObjectDataSource ID="odsDominios" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appProyVentas.Clases.Dominios">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlDominio" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
	
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
			<asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn-sm btn-info btn-block" OnClick="btnNuevo_Click" runat="server" Text="Nuevo solicitud" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Administrar <small>Solicitudes:</small></h1>
											<asp:RadioButtonList ID="rblTipoSolicitud" CssClass="form-control" OnSelectedIndexChanged="rblTipoSolicitud_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal" runat="server">
												<asp:ListItem Text="ACTUALES" Value="ACTUALES"></asp:ListItem>
												<asp:ListItem Text="HISTORICOS" Value="HISTORICOS"></asp:ListItem>
											</asp:RadioButtonList>
											<%--<asp:DropDownList ID="ddlDominio" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlDominio_SelectedIndexChanged"  DataSourceID="odsDominiosOnly" DataTextField="dominio" DataValueField="dominio" OnDataBound="ddlDominio_DataBound" runat="server"></asp:DropDownList>
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
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">color</th>
															<th class="text-nowrap">RRAZON SOCIAL</th>
															<th class="text-nowrap">SOLICITUD</th>
															<th class="text-nowrap">CONTACTO</th>
															<th class="text-nowrap">TELEFONO</th>
															<th class="text-nowrap">EMAIL</th>
															<th class="text-nowrap">UBICACION</th>
															<th class="text-nowrap">FECHA SOLICITU</th>
															<th class="text-nowrap">FECHA ENTREGA</th>
															<th class="text-nowrap">ETAPA ACTUAL</th>
															<th class="text-nowrap">OPERADOR</th>
															<th class="text-nowrap">MONTO TOTAL</th>
															<th class="text-nowrap">DESCUENTO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1"  runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"COLORES\" + Eval("COLOR") +  ".PNG" %>' /></td>
															<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("CLI_RAZON_SOCIAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("SOLICITUD") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto" runat="server" Text='<%# Eval("contacto") %>'></asp:Label></td>
															<td><asp:Label ID="lblValor" runat="server" Text='<%# Eval("telefono") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("correoelectronico") %>'></asp:Label></td>
																<td><asp:Label ID="Label22" runat="server" Text='<%# Eval("ubicacion") %>'></asp:Label></td>
																<td><asp:Label ID="Label12" runat="server" Text='<%# Eval("fecha_solicitud") %>'></asp:Label></td>
																<td><asp:Label ID="Label32" runat="server" Text='<%# Eval("fecha_entrega") %>'></asp:Label></td>
																<td><asp:Label ID="Label42" runat="server" Text='<%# Eval("etapa_actual") %>'></asp:Label></td>
																<td><asp:Label ID="Label62" runat="server" Text='<%# Eval("operador") %>'></asp:Label></td>
																<td><asp:Label ID="Label621" runat="server" Text='<%# Eval("monto_total") %>'></asp:Label></td>
																<td><asp:Label ID="Label612" runat="server" Text='<%# Eval("descuento") %>'></asp:Label></td>
															<td>
															<%--	<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("dominio") +"|"+Eval("codigo") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("dominio") +"|"+Eval("codigo") %>' OnClick="btnEliminar_Click" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" runat="server" Text="Eliminar" ToolTip="Borrar registro" />--%>
                                                                
																<asp:Button ID="btnEtapas" class="btn btn-success btn-sm" CommandArgument='<%# Eval("SOLICITUD") %>' OnClick="btnEtapas_Click" runat="server" Text="Nuevo" ToolTip="Ver etapas" />
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
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Solicitud</legend>
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Dominio:</label>
						<div class="col-md-6">
                            <asp:Label ID="lblNombreDominio" runat="server" Text=""></asp:Label>
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
						<%--	<asp:DropDownList ID="ddlCliente" class="form-control"  DataSourceID="odsClientes" DataTextField="CLI_RAZON_SOCIAL" DataValueField="CLI_ID_CLIENTE" OnDataBound="ddlCliente_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Cliente:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlCliente" class="form-control col-md-6"  DataSourceID="odsClientesTodos" DataTextField="CLI_RAZON_SOCIAL" DataValueField="CLI_ID_CLIENTE" OnDataBound="ddlCliente_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
				<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Contacto:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtContacto" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtContacto" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Telefono:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtTelefono" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtTelefono" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Email:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
                        
					</div>
					<!-- end form-group row -->
						<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Ubicacion:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtUbicacion" class="form-control" runat="server"></asp:TextBox>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Comentarios:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtComentarios" class="form-control" runat="server"></asp:TextBox>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Ubicacion ventana:</label>
						<div class="col-md-6">
							<asp:TextBox ID="txtUbicacionVentana" class="form-control" runat="server"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo cortina:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlTipoCortina" class="form-control col-md-6"  DataSourceID="odsClientesTodos" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlTipoCortina_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo tela cortina:</label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlTipoTelaCortina" class="form-control col-md-6"  DataSourceID="odsClientesTodos" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlTipoTelaCortina_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoTelaCortina" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<%--<asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />--%>
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
		<asp:View ID="View3" runat="server">
			
									
										<!-- begin page-header -->
											<h1 class="page-header">ETAPAS SOLICITUD<small></small></h1>
											<%--<asp:RadioButtonList ID="RadioButtonList1" CssClass="form-control" OnSelectedIndexChanged="rblTipoSolicitud_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal" runat="server">
												<asp:ListItem Text="ACTUALES" Value="ACTUALES"></asp:ListItem>
												<asp:ListItem Text="HISTORICOS" Value="HISTORICOS"></asp:ListItem>
											</asp:RadioButtonList>--%>
											<%--<asp:DropDownList ID="ddlDominio" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlDominio_SelectedIndexChanged"  DataSourceID="odsDominiosOnly" DataTextField="dominio" DataValueField="dominio" OnDataBound="ddlDominio_DataBound" runat="server"></asp:DropDownList>
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
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">color</th>
															<th class="text-nowrap">RRAZON SOCIAL</th>
															<th class="text-nowrap">SOLICITUD</th>
															<th class="text-nowrap">CONTACTO</th>
															<th class="text-nowrap">TELEFONO</th>
															<th class="text-nowrap">EMAIL</th>
															<th class="text-nowrap">UBICACION</th>
															<th class="text-nowrap">FECHA SOLICITU</th>
															<th class="text-nowrap">FECHA ENTREGA</th>
															<th class="text-nowrap">ETAPA ACTUAL</th>
															<th class="text-nowrap">OPERADOR</th>
															<th class="text-nowrap">MONTO TOTAL</th>
															<th class="text-nowrap">DESCUENTO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater2"  runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"COLORES\" + Eval("COLOR") +  ".PNG" %>' /></td>
															<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("CLI_RAZON_SOCIAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("SOLICITUD") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto" runat="server" Text='<%# Eval("contacto") %>'></asp:Label></td>
															<td><asp:Label ID="lblValor" runat="server" Text='<%# Eval("telefono") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("correoelectronico") %>'></asp:Label></td>
																<td><asp:Label ID="Label22" runat="server" Text='<%# Eval("ubicacion") %>'></asp:Label></td>
																<td><asp:Label ID="Label12" runat="server" Text='<%# Eval("fecha_solicitud") %>'></asp:Label></td>
																<td><asp:Label ID="Label32" runat="server" Text='<%# Eval("fecha_entrega") %>'></asp:Label></td>
																<td><asp:Label ID="Label42" runat="server" Text='<%# Eval("etapa_actual") %>'></asp:Label></td>
																<td><asp:Label ID="Label62" runat="server" Text='<%# Eval("operador") %>'></asp:Label></td>
																<td><asp:Label ID="Label621" runat="server" Text='<%# Eval("monto_total") %>'></asp:Label></td>
																<td><asp:Label ID="Label612" runat="server" Text='<%# Eval("descuento") %>'></asp:Label></td>
															<td>
															<%--	<asp:Button ID="btnEditar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("dominio") +"|"+Eval("codigo") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("dominio") +"|"+Eval("codigo") %>' OnClick="btnEliminar_Click" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" runat="server" Text="Eliminar" ToolTip="Borrar registro" />--%>
                                                                
																<asp:Button ID="btnEtapas" class="btn btn-success btn-sm" CommandArgument='<%# Eval("SOLICITUD") %>' OnClick="btnEtapas_Click" runat="server" Text="Nuevo" ToolTip="Ver etapas" />
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
    </asp:MultiView>
	
			
		</div>
		<!-- end #content -->
</asp:Content>
